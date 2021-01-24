    class SalesPeeps
    {
        static string[] people = new string[8];
        static double[] salaries = new double[8];
        static void Main()
        {
            getInformation();
        }
        static void getInformation()
        {
            int i = 0;
            do
            {
                Console.WriteLine("Please input a the sales person's last name.");
                i++;
            } while (i < people.Length);
        }
    }
