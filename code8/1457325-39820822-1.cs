    Job[] jobArray = new Job[5];
    for (int i = 0; i < jobArray.Length; i++)
    {
       Job job = new Job();
       Console.WriteLine("Job " + i);
       Console.WriteLine("Enter description:");
       job.Desciption = Console.ReadLine();
       Console.WriteLine("Enter hours:");
       job.Hours = Console.ReadLine();
       Console.WriteLine("Enter pay:");
       job.Pay = Console.ReadLine();
       jobArray[i] = job;
    }
