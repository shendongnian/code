    using System;
    using System.Linq;
    namespace Test.SO47928637
    {
        public class Jobs
        {
            public string JobName { get; set; }
            public int JobTime { get; set; }
            public override string ToString()
            {
                return "Job" + JobName + ": " + JobTime;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("This program simulates SJN of five jobs");
                Console.WriteLine("Please enter the time in ms for the following jobs");
                //Reading in the Times for jobs 
                Console.WriteLine("Job A Time (ms): ");
                string TimeOneText = Console.ReadLine();
                int JobTimeOne = int.Parse(TimeOneText);
                Jobs jobsA = new Jobs { JobName = "A", JobTime = JobTimeOne };
                Console.WriteLine(jobsA);//Error checking 
                Console.WriteLine("Job B Time (ms): ");
                string TimeTwoText = Console.ReadLine();
                int JobTimeTwo = int.Parse(TimeTwoText);
                Jobs jobsB = new Jobs { JobName = "B", JobTime = JobTimeTwo };
                Console.WriteLine(jobsB);//Error checking
                Console.WriteLine("Job C Time (ms): ");
                string TimeThreeText = Console.ReadLine();
                int JobTimeThree = int.Parse(TimeThreeText);
                Jobs jobsC = new Jobs { JobName = "C", JobTime = JobTimeThree };
                Console.WriteLine(jobsC);//Error checking
                Console.WriteLine("Job D Time (ms): ");
                string TimeFourText = Console.ReadLine();
                int JobTimeFour = int.Parse(TimeFourText);
                Jobs jobsD = new Jobs { JobName = "D", JobTime = JobTimeFour };
                Console.WriteLine(jobsD);//Error checking
                Console.WriteLine("Job E Time (ms): ");
                string TimeFiveText = Console.ReadLine();
                int JobTimeFive = int.Parse(TimeFiveText);
                Jobs jobsE = new Jobs { JobName = "E", JobTime = JobTimeFive };
                Console.WriteLine(jobsE);//Error checking
                Console.ReadLine();
                //Create an array for Job titles
                Jobs[] JobName = { jobsA, jobsB, jobsC, jobsD, jobsE };
                var items = JobName.OrderBy(o => o.JobName).ToList();
                Console.WriteLine("Order by JobName");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
                items = JobName.OrderBy(o => o.JobTime).ToList();
                Console.WriteLine("Order by JobTime");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadLine();
            }
        }
    }
