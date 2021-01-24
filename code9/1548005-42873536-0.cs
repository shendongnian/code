    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
    class Program
    {
        static bool tooHigh;
        static int waistMeasurment;    
        static void Main(string[] args)
        {
            GetVariables();
        }
        public static void GetVariables() //This method gets the users height & waist measurments 
                                          //and calls the 'ValidateWaist' and 'ValidateHeight' methods for validation
        {
            Console.Write("What is your waist measurment? "); //This prints a string prompting the user to input their waist measurment
            int.TryParse(Console.ReadLine(), out waistMeasurment); //This writes the users input under the string 'waistMeasurment'
            ValidateWaist();
            if (tooHigh == true)
                {
                int.TryParse(Console.ReadLine(), out waistMeasurment); ;
                ValidateWaist();
            }
        }
        public static void ValidateWaist() //This method validates the user input so that it fits within the minimum bound
        {
            if (waistMeasurment < 60) //Checks the lower bound of the waist limit
            {
                Console.Write("Your waist measurment must be above 59cm? "); //Output error feedback
                tooHigh = true;
            }
            else
            {
                tooHigh = false;
            }
        }
    }
    
}
