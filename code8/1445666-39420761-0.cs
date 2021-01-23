     static void Main(string[] args)
            {
                Console.WriteLine("this program can convert between units in different settings like currency, speed, and weight");
                //define vars
                double miles, kilometers, pounds, kilograms, euros, dollars;
                Int16 number, first, second, third;
                //get user input
                Console.WriteLine("please choose what you want to convert and enter the number associated with it 1speed, 2weight, 3currency.");
                number = Convert.ToInt16(Console.ReadLine());
                if (number == 1)
                {   //speed conversion
                    Console.WriteLine("you have chosen to convert speed between miles and kilometers");
                    Console.WriteLine("which would you like to convert from 1miles, or 2kilometers ?");
                    first = Convert.ToInt16(Console.ReadLine());
                    if (first == 1)
                        Console.Write("enter miles: ");
                    miles = Convert.ToDouble(Console.ReadLine());
                    kilometers = miles * 1.60934;
    
                    Console.WriteLine("your speed in kilometers per hour is" + kilometers + "per hour");
                }
                else
                {
                    Console.Write("enter kilometers: ");
                    kilometers = Convert.ToDouble(Console.ReadLine());
                    miles = kilometers * .621;
    
                    Console.WriteLine("your speed in miles per hour is" + miles + "per hour");
                }
               if (number == 2)
                {
                    //weight conversion
                    Console.WriteLine("you have chosen to convert weight between US pounds and kilograms");
                    Console.WriteLine("which would you like to convert from 1pounds, or 2kilograms ?");
                    second = Convert.ToInt16(Console.ReadLine());
    
                    if (second == 1)
                    {
                        Console.Write("enter pounds: ");
                        pounds = Convert.ToDouble(Console.ReadLine());
                        kilograms = pounds * 2.20462;
    
                        Console.WriteLine("your weight in kilograms is" + kilograms + ".");
                    }
                    else
                    {
                        Console.Write("enter kilograms: ");
                        kilograms = Convert.ToDouble(Console.ReadLine());
                        pounds = kilograms * .453592;
    
                        Console.WriteLine("your weight in pounds is" + pounds + ".");
                    }
                }
                else
                {
                    {  //currency conversion.
                        Console.WriteLine("you have chosen to convert currency between dollars and euros using the conversion factors as of 9 - 9 - 16");
                        Console.WriteLine("which would you like to convert from 1dollars, or 2euros ?");
                        third = Convert.ToInt16(Console.ReadLine());
                    }
                    if (third == 1)
                    {
                        Console.Write("enter dollars");
                        dollars = Convert.ToDouble(Console.ReadLine());
                        euros = dollars * .89;
                        Console.WriteLine("your" + dollars + "dollars is equal to " + euros + "euros.");
                    }
                    else
                    {
                        Console.Write("enter euros");
                        euros = Convert.ToDouble(Console.ReadLine());
                        dollars = euros * 1.12;
                        Console.WriteLine("your" + euros + "euros is equal to " + dollars + "dollars.");
                    }
                }
    
                Console.WriteLine("thank you and I hope you converted all that you need to.");
                Console.ReadKey();
            }
