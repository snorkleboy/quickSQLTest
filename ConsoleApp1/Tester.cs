using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Npgsql;

namespace ConsoleApp1
{
    public class Tester
    {
        private Action toTest;
        private int timesToTest;
        public TimeSpan averageTime;
        public TimeSpan totalTime;
        private int timesRan = 0;
        private string name;
        public Tester(Action toTest, int timesToTest, string name)
        {
            this.toTest = toTest;
            this.timesToTest = timesToTest;
            this.name = name;
        }
    
        public Tester test()
        {
            timesRan = 0;
            totalTime = TimeSpan.Zero;
            for (var i = 0; i < timesToTest; i++)
            {
                var runTime = timedRun();
                totalTime += runTime;
                timesRan++;
            }
            averageTime = totalTime / timesRan;
            return this;
        }
    
        private TimeSpan timedRun()
        {
            Stopwatch s = Stopwatch.StartNew();
            toTest();
             s.Stop();
            return s.Elapsed;
        }

        public void printResult()
        {
            Console.WriteLine(name + "- averageTime:" + averageTime + " totalTime:" + totalTime);
        }
    
    }
}