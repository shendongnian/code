    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    
        public class BaseClass
        {
        }
    
        public class BaseClassList : List<BaseClass>
        {
            public DateTime CallDate { get; set; }
    
            public BaseClassList(IEnumerable<BaseClass> elements, DateTime CallDate)
                : base(elements)
            {
                this.CallDate = CallDate;
            }
        }
    
        public static class BaseClassExtensions
        {
            public static DateTime Date(this BaseClass ext, BaseClassList bcl)
            {
                return bcl.CallDate;
            }
        }
    
        class Program
        {
            public static List<BaseClass> Func(DateTime d)
            {
                BaseClass A = new BaseClass();
                BaseClass B = new BaseClass();
                return new List<BaseClass>() { A, B };
            }
    
            static void Main(string[] args)
            {
                DateTime d1 = new DateTime(2017, 5, 1);
                DateTime d2 = new DateTime(2018, 5, 1);
                List<DateTime> dates = new List<DateTime>() { d1, d2 };
    
    
                List<BaseClassList> myList = new List<BaseClassList>();
    
                foreach (DateTime d in dates)
                    myList.Add(new BaseClassList(Func(d), d));
    
                foreach(var el in myList)
                    foreach (BaseClass bc in el)
                        Console.WriteLine(bc.Date(el));
            }
        }
    }
