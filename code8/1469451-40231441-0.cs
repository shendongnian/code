     private static void ParseDouble()
        {
            string sDouble = "12.00";
            double dValue = double.Parse(sDouble);
            Console.WriteLine(dValue.ToString());
            sDouble = "12.14";
            dValue = double.Parse(sDouble);
            Console.WriteLine(dValue.ToString());
        }
