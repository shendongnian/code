    public class Sum
    {
        static void Main(string[] args)
        {
            //Declare Variables
            int intEnterInteger;
            string strEnterInteger;
            int intResult = 0;
            int intLimit = 999;
            Console.WriteLine("Enter multiple numbers. Calculate results by entering 999");
            strEnterInteger = Console.ReadLine();
            intEnterInteger = Convert.ToInt32(strEnterInteger);
            intResult += intEnterInteger;
            //Accept user input
            while (intEnterInteger != intLimit)
            {
                //Read user input
                Console.WriteLine("Enter another number");
                strEnterInteger = Console.ReadLine();
                intEnterInteger = Convert.ToInt32(strEnterInteger);
                intResult += intEnterInteger;
            }
            Console.WriteLine();
                Console.WriteLine("Result: {0}", intResult - intLimit);
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
        }
    }
}
