    public static class Common
        {
            public static double getPaymentAmount(double value)
            {
                double monthlyPayment = value / 24;
                return monthlyPayment;
            }
        }
    
        class Customer  // class declaration
        {
            public int customerNumber { get; set; }
            public string customerName { get; set; }
            public double amountDue { get; set; }
    
            // Cust class constructor values assigned through accessors
            public Customer(int number, string name, double due)
            {
                customerNumber = number;
                customerName = name;
                amountDue = due;
            }
    
            // override ToString method
            public override string ToString()
            {
                return ("Credit Customer " + customerNumber + " " + customerName + " AmountDue is " + amountDue.ToString("C2") +
                    " Interest rate is " + ((this as CreditCustomer!=null) ? ((CreditCustomer)this).creditRate.ToString() : "N/A")); // creditRate causes error
            }
        }
    
        // class derived from Customer
        class CreditCustomer : Customer
        {
            public double creditRate { get; set; }
    
            // CreditCustomer class constructor values
            public CreditCustomer(int number, string name, double due, double rate)
                : base(number, name, due)
            {
                customerNumber = number;
                customerName = name;
                amountDue = due;
                creditRate = rate;
            }
    
            // override ToString method
            public override string ToString()
            {
                return (base.ToString() + "\nMonthly payment is " + Common.getPaymentAmount(this.amountDue));
            }
    
        }
    
        // wrapper for Main
        class Assignment06
        {
            static void Main(string[] args)
            {
                // instantiate an array of 5 CreditCustomer objects
                const int NUM_OF_CUSTS = 1;
                CreditCustomer[] creditCustomer = new CreditCustomer[NUM_OF_CUSTS];
    
                // get user input
                for (int i = 0; i < creditCustomer.Length; i++)
                {
                    Console.Write("Enter customer number: > ");
                    int number = Convert.ToInt32(Console.ReadLine());
    
                    Console.Write("Enter name: > ");
                    string name = Convert.ToString(Console.ReadLine());
    
                    Console.Write("Enter amount due: > ");
                    double due = Convert.ToDouble(Console.ReadLine());
    
                    Console.Write("Enter interest rate: > ");
                    double rate = Convert.ToDouble(Console.ReadLine());
    
                    creditCustomer[i] = new CreditCustomer(number, name, due, rate);
                }
    
                // Print to Console Summary Section
                Console.WriteLine("\nSummary\n");
                double totalDue = 0.00;
                for (int count = 0; count < creditCustomer.Length; count++)
                {
                    Console.WriteLine(creditCustomer[count].ToString());
                    totalDue += creditCustomer[count].amountDue;
                }
                Console.WriteLine("\nAmountDue for all Customers is {0}", totalDue.ToString("C2"));
    
                // Print to Console Payment Section
                Console.WriteLine("\nPayment Information\n");
                double monthlyDue = 0.00;
                for (int count = 0; count < creditCustomer.Length; count++)
                {
                    double payAmt = Common.getPaymentAmount(creditCustomer[count].amountDue);
                    Console.WriteLine(creditCustomer[count].ToString());
                    monthlyDue += creditCustomer[count].amountDue / 24;
                }
                Console.WriteLine("\nMonthly payments for all Customers is {0}", monthlyDue.ToString("C2"));
                Console.ReadKey();
            } // end Main
    
    
        } // end class wrapper for Main
