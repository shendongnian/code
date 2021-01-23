    using System;
    using static System.Console;
    using static System.Convert;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public struct MyUnits
            {
                public const double Centimeter = 0.3037;
                public const double Liters = 3.78;
                public const double Kilometer = 1.60;
                public const double Kilogram = 0.453;
            }
    
            enum MyUnitEnum
            {
                Centimeters,
                Liters,
                Kilometer,
                Kilogram,
            }
    
            static void Main(string[] args)
            {
                double centimeter, liters, kilometer, kilogram, final = 0;
                string unitWord;
                WriteLine("Enter the value you wanted to convert: ");
                int input = ToInt32(ReadLine());
                WriteLine("\n Press Any Of The Given Choices \n I->convert from inches to centimeters." +
                          "\n G->convert from gallons to liters.\n M->convert from mile to kilometer." +
                          "\n P->convert from pound to kilogram.");
    
                char choice = Char.ToLower(ToChar(ReadLine()));
    
                if (choice == 'i')
                {
                    final = input / MyUnits.Centimeter;
                    unitWord = MyUnitEnum.Centimeters.ToString();
                }
                else if(choice == 'g')
                {
                    final = input / MyUnits.Liters;
                    unitWord = MyUnitEnum.Liters.ToString();
    
                }
                else if (choice == 'm')
                {
                    final = input / MyUnits.Kilometer;
                    unitWord = MyUnitEnum.Kilometer.ToString();
                }
                else if (choice == 'p')
                {
                    final = input / MyUnits.Kilogram;
                    unitWord = MyUnitEnum.Kilogram.ToString();
                }
                else
                {
                    unitWord = "You Enter A Invalid Choice, Please Enter A Valid Choice...!";
                }
    
                WriteLine("In " + unitWord + final);
                ReadKey();
            }
        }
    }
