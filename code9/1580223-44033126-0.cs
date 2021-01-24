        static private double getTotal(string str)
        {
            double total = 0;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
            foreach (int c in asciiBytes)
            {
                double dC = c;
                total = total + c;
                double cXor2 = c ^ 2;
                double c6 = c * 6;
                double fiveCXor2 = 5 * cXor2;
                double semiFinal = fiveCXor2 / c6;
                double final = total * semiFinal;
                Console.WriteLine("c = " + (c).ToString());
                Console.WriteLine("c ^ 2 = " + (cXor2).ToString());
                Console.WriteLine("c * 6 = " + (c6).ToString());
                Console.WriteLine("5 * (c ^ 2) = " + (fiveCXor2).ToString());
                Console.WriteLine("semi final = " + semiFinal);
                Console.WriteLine("final = " + final);
                Console.WriteLine("--------------------------------------------");
                total = total * (5 * (c ^ 2) / (c * 6));
                Console.WriteLine("TOTAL = " + total);
                Console.WriteLine("--------------------------------------------");
            }
            return Math.Round(total);
        }
