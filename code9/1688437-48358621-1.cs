    using System;
    using System.Threading;
    
        public class Program
        {
            public class C1
            {
    
                private static object obj = new object();
    
    
                public void Ten() 
                {
                    //lock(obj)
                    //{
                        for(int i=1; i<=10; i++)
                        {
                            Console.WriteLine(i + " " + Thread.CurrentThread.Name);
                            Thread.Sleep(1000); //<-- add sleep
                        }
                    //}
                }
    
            }
            public static void Main()
            {
                Thread t1 = new Thread(new ThreadStart(new C1().Ten));
                Thread t2 = new Thread(new ThreadStart(new C1().Ten));
    
                t1.Name = "thread1";
                t2.Name = "thread2";
    
                t1.Start(); 
                t2.Start();
            }
    }
