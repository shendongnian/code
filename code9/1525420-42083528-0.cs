            for (n1 = 2; n1 <= 18; n1++)
            {
                for (n2 = 2; n2 <= n1; n2++)
                {
                    Console.Write("{0} ", n2);
                    n2++;
                }
                n1++;
                Console.WriteLine();
            }
            for (n1 = 2; n1 <= 18; n1++)
            {
                for (n2 = 2; n2 <= 18 - n1; n2++)
                {
                    Console.Write("{0} ", n2);
                    n2++;
                }
                n1++;
                Console.WriteLine();
            }
