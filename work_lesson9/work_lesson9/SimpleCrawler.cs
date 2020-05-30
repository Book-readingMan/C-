using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler {
  class SimpleCrawler {
    private Hashtable urls = new Hashtable();
    private int count = 0;
   // static  private string url = "www.cnblogs.com";
    static void Main(string[] args) {
      SimpleCrawler myCrawler = new SimpleCrawler();
            //string startUrl = "http://www.cnblogs.com/dstang2000/";
      string startUrl = "http://www.cnblogs.com/dstang2000/";
      if (args.Length >= 1) startUrl = args[0];
      myCrawler.urls.Add(startUrl, false);//加入初始页面
      new Thread(myCrawler.Crawl).Start();
    }

    private void Crawl() {
      Console.WriteLine("开始爬行了.... ");
            //string pattern = @"^(http|https)[:][/]{2}[w]{3}[.](cnblogs)[.](com)";
            string pattern = @"^(http|https)(://www.cnblogs.com)";
            
      while (true) {
        string current = null;
        foreach (string url in urls.Keys) {
          if ((bool)urls[url]) continue;
          current = url;
        }

        if (current == null || count > 10) break;
        if (!new Regex(pattern).IsMatch(current))
                    continue;
       Console.WriteLine("爬行" + current + "页面!");
        string html = DownLoad(current); // 下载
        urls[current] = true;
       
        Parse(html);//解析,并加入新的链接
        count++;
        Console.WriteLine("爬行结束");
        
      }
            Console.WriteLine("全部爬行结束！！");
            Console.ReadKey();
        }

    public string DownLoad(string url) {
      try {
        WebClient webClient = new WebClient();
        webClient.Encoding = Encoding.UTF8;
        string html = webClient.DownloadString(url);
        string fileName = count.ToString();
        File.WriteAllText(fileName, html, Encoding.UTF8);
        return html;
      }
      catch (Exception ex) {
        Console.WriteLine(ex.Message);
        return "";
      }
    }

    private void Parse(string html) {
      string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+(.html)[""']";
      MatchCollection matches = new Regex(strRef).Matches(html);
      foreach (Match match in matches) {
        strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                  .Trim('"', '\"', '#', '>');

       if (strRef.Length == 0) continue;
                if (strRef.ElementAt(0) != 'h')
                    strRef = strRef.Insert(0, "https://www.cnblogs.com");

       if (urls[strRef] == null) urls[strRef] = false;
     
       }  

    
    }  
    }
}
