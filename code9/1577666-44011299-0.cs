            Sample sample1 = new Sample(1.0, 2.0, 3.0, 4.0);
            Sample sample2 = new Sample(3.0, 4.0, 5.0, 6.0);
            TestResult tTest = Sample.StudentTTest(sample1, sample2);
            Console.WriteLine("t = {0}", tTest.Statistic);
            Console.WriteLine("P = {0} ({1})", tTest.Probability, tTest.Type);
