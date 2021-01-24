    using System;
    
    namespace TwoDArray_47478344
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string[,] customers = { { "Jay", "123 Fake Street", "212 111 1111" }, { " Pete", "123 Fake Rd", "212 222 2222" }, { "Will", "112 Fake Av", "212 333 3333" } };
                string cusInfo;
                bool phoneNumberFound = false;
    
                Console.Write("Enter your phone #:");
                cusInfo = Convert.ToString(Console.ReadLine());
    
                //loop through your customers
                for (int i = 0; i < customers.Length; i++)
                {
                    if (customers[i,2].ToString() == cusInfo)//if you find a matching phone number
                    {
                        Console.WriteLine();
                        Console.WriteLine("Customer Name:\t{0}", customers[i, 0]);
                        Console.WriteLine("Address:\t{0}", customers[i, 1]);
                        Console.WriteLine("Phone Number:\t{0}", customers[i, 2]);
                        Console.WriteLine();
                        Console.ReadLine();
                        phoneNumberFound = true;//set the trigger to true
                        break;//stop looping
                    }
                }
                if (!phoneNumberFound)
                {
                    Console.WriteLine("Your phone number could not be found.");
                }
            }
        }
    }
