    using System;
    using System.Collections.Generic;
    
    namespace TwoDArray_47478344
    {
        class Program
        {
            public static List<CustomerInfo> CustomerList = new List<CustomerInfo>();//the list that will contain our customers(instead of the 2d array, I'm using a custom class).
    
            static void Main(string[] args)
            {
    
                MakeSomeCustomers();//populate the list of customers to cross-reference
    
                string cusProvidedInfo;//we'll use and re-use this to query the list of customers
    
                Console.Write("Enter your phone #:");//ask the user for phone
                cusProvidedInfo = Convert.ToString(Console.ReadLine());//ask the user for phone
    
                CustomerInfo currentCustomer = CustomerList.Find(p => p.Phone == cusProvidedInfo);//check if the supplied phone number is in our list of customers
    
                if (currentCustomer == null)//if we don't have a customer, the phone number wasn't found, lets ask for first name
                {
                    Console.WriteLine("\nCould not find you by phone number.\nPlease try entering your first name.");
                    cusProvidedInfo = Console.ReadLine().Trim();
                    currentCustomer = CustomerList.Find(p => p.Name == cusProvidedInfo);
                }
    
                if (currentCustomer == null)//well... we couldn't find the customer based on Phone number, nor based on first name
                {
                    Console.WriteLine("Still can't find you. Looks like you'll have to sign up.");
                }
                else
                {
                    //we did find the customer, we can show the customer info
                    Console.WriteLine();
                    Console.WriteLine("Customer Name:\t{0}", currentCustomer.Name);
                    Console.WriteLine("Address:\t{0}", currentCustomer.Address);
                    Console.WriteLine("Phone Number:\t{0}", currentCustomer.Phone);
                    Console.WriteLine();
                }
                Console.ReadLine();
                
            }
    
    
            /// <summary>
            /// just creating some customers to search against
            /// </summary>
            private static void MakeSomeCustomers()
            {
                CustomerList.Add(new TwoDArray_47478344.CustomerInfo { Name = "Jay", Address = "123 Fake Street", Phone = "212 111 1111" });
                CustomerList.Add(new TwoDArray_47478344.CustomerInfo { Name = "Pete", Address = "123 Fake Road", Phone = "212 222 2222" });
                CustomerList.Add(new TwoDArray_47478344.CustomerInfo { Name = "Will", Address = "123 Fake Av", Phone = "212 333 3333" });
            }
        }
    
        /// <summary>
        /// Instead of using a 2d array, I create a custom class to host the customer info
        /// </summary>
        public class CustomerInfo
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
        }
    }
