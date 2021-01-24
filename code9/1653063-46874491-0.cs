    namespace ICNumber
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your Singapore IC starting with T:");
            string ICnumber = Convert.ToString(Console.ReadLine());
            int totalsum = 0;
            for (int k = 1; k < 8; k++)
            {
                int number = ICnumber.IndexOf(ICnumber, k);
                int digitsum = 0;
                if (k is 1)
                    digitsum = number * 2;
                if (k is 2)
                    digitsum = number * 7;
                if (k is 3)
                    digitsum = number * 6;
                if (k is 4)
                    digitsum = number * 5;
                if (k is 5)
                    digitsum = number * 4;
                if (k is 6)
                    digitsum = number * 3;
                if (k is 7)
                    digitsum = number * 2;
                totalsum = totalsum + digitsum;
            }
            int validcheck = (totalsum + 4) % 11;
            string Validcheck = Convert.ToString(validcheck);
            int letter = ICnumber.IndexOf(ICnumber, 8);
            string Letter = Convert.ToString(letter);
            string validity=""; //declare the variable here
            if (Validcheck == "0" && Letter == "J")
            {
                validity = "Valid";//remove the keyword string. If you use the keyword you create a new variable (different from the one above)
            }
            if (Validcheck == "1" && Letter =="Z")
            {
                validity = "Valid"; //keep on referencing the variable everywhere you need it
            }
            if (Validcheck == "2" && Letter =="I")
            {
                validity = "Valid";
            }
            if (Validcheck == "3" && Letter =="H")
           .
           .
           .
