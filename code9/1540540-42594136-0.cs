     static void Main()
        {
            int nNumberOfTestCases = 0;
            var input = 
            int.TryParse(Console.ReadLine(), out nNumberOfTestCases);
            String[] strTestCases = new String[nNumberOfTestCases];
           
            for (int nTestCase = 0; nTestCase < nNumberOfTestCases; nTestCase++)
            {
                strTestCases[nTestCase] = Console.ReadLine();
            }
            for (int nTestCase = 0; nTestCase < nNumberOfTestCases; nTestCase++)
            {
                if (strTestCases[nTestCase].SequenceEqual(strTestCases[nTestCase].Reverse()))
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
              
            }
            Console.ReadKey();
        }
