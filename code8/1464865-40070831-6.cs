    using System;
    using System.Collections.Generic;
    public class Program
    {
        public delegate void DoSomething();
        public static void Main(string[] args)
        {
            List<DoSomething> lstOfDelegate = new List<DoSomething>();
            int iCnt = 0;
            while (iCnt < 10)
            {
                lstOfDelegate.Add(delegate { Console.WriteLine(iCnt); });
                iCnt++;
            }
    
            foreach (var item in lstOfDelegate)
            {
                item.Invoke();
            }
            Console.ReadLine();
        }
    }
