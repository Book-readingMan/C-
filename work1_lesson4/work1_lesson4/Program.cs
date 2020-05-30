using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work1_lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Listener listener = new Listener();
            listener.clock.Go();
        }
    }

    public delegate void ClockHandler(ClockEventArgs args);

    public class ClockEventArgs
    {
        public int sec { get; set; }
        public int min { get; set; }
        public int hour { get; set; }
    }

    class Clock
    {
        public event ClockHandler Run;
        public void Go()
        {
            ClockEventArgs args = new ClockEventArgs()
            {
                hour = 0,
                min = 0,
                sec = 0
            };
            while(true)
            {
                Run(args);
                args.sec++;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }

    class Listener
    {
        public Clock clock = new Clock();

        public Listener()
        {
            clock.Run += new ClockHandler(Tick);
            clock.Run += new ClockHandler(Alarm);
        }

        void Tick(ClockEventArgs args)
        { 
            if (args.sec == 60)
                args.min++;
            if (args.min == 60)
                args.hour++;
            if (args.hour == 24)
                args.hour = 0; 
            Console.WriteLine("Clock is Ticking...");
        }

        void Alarm(ClockEventArgs args)
        {
            if (args.sec > 20&&args.sec<30)
                Console.WriteLine("Clock is Alarming...");
        }

    }

}
