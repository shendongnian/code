        static void Main(string[] args)
        {
            TimeSpan span = new TimeSpan(0, 0, 0, 7, 0);
            //Your array of DateTimes
            DateTime[] dateTimes = new DateTime[]
            {
                new DateTime(2017, 04, 18, 0, 0, 0),
                new DateTime(2017, 04, 18, 0, 0, 7),
                new DateTime(2017, 04, 18, 0, 0, 15),
                new DateTime(2017, 04, 18, 0, 0, 21),
            };
            //Check through whole array of DateTimes, in sequence
            for (int i = 0; i < dateTimes.Count() - 1; i++)
            {
                if (dateTimes[i + 1] - dateTimes[i] <= span)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("NOT OK");
                }
            }
            //Output of this example:
            //OK
            //NOT OK
            //OK
