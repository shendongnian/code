    using System;
    using System.Collections.Generic;
    using System.Threading;
    
    class Program
    {
        static void Main(string[] args)
        {
            List<IWorkerClass> workerClasses = new List<IWorkerClass>();
            for (int i = 0; i < 5; i++)
            {
                workerClasses.Add(new WorkerClass("worker" + i.ToString()));
            }
    
            foreach (IWorkerClass wc in workerClasses)
            {
                IWorkerClass temp = wc;
                Thread workerThread = new Thread(() => temp.StartWhileLoop());
                workerThread.Start();
            }
    
            Thread checkerThread = new Thread(() => ThreadReader(workerClasses));
            checkerThread.Start();
    
            Console.ReadKey();
        }
    
        static void ThreadReader(List<IWorkerClass> workers)
        {
            while (true)
            {
                foreach (var worker in workers)
                {
                    Console.WriteLine($"{worker.name} - {worker.noOfLoops}");
                }
    
                Thread.Sleep(20000);
            }
        }
    }
    public interface IWorkerClass
    {
        string name { get; set; }
        int noOfLoops { get; set; }
        void StartWhileLoop();
    }
    
    public class WorkerClass : IWorkerClass
    {
        public string name { get; set; }
        public WorkerClass(string name)
        {
            this.name = name;
        }
        public int noOfLoops { get; set; }
    
        public void StartWhileLoop()
        {
            while (true)
            {
                Thread.Sleep(3000);
                noOfLoops += 1;
    
            }
        }
    }
