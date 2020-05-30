using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1_lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数：");
            int num =int.Parse(Console.ReadLine());
            if (num <= 0)
            {
                Console.WriteLine("无质因子");
                return;
            }
            
            ShowResults(num);
            Console.ReadKey();
        }
        static void ShowResults(int num)
        {
           
           Console.WriteLine("质因数为：");
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {

                    if (num % i == 0)
                    {
                        num /= i;
                        Console.WriteLine(i);
                    }

            }
            if (num != 1)
                Console.WriteLine(num);
        }
    }
}
