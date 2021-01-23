    static void checking(double n, ref double max, ref double smax)
        {
            if (n > max)
            {
                smax = max;
                max = n;
            }
            else if (n > smax)
            {
                smax = n;
            }
        }
        static void Main(string[] args)
        {
            double n = 1, max = Double.MinValue, smax = Double.MinValue;
            int i = 0, stopInput = 0;
            while (n != 0 && i < 10)
            {
                Console.WriteLine("Input number");
                n = double.Parse(Console.ReadLine());
                if (n % 1 == 0 && n !=0) //this (n % 1 == 0) part checks if number is not decimal
                {
                    if (n != max && n != smax)
                        checking(n, ref max, ref smax);
                    i++;
                }
                else if(n == 0)
                {
                    stopInput =1;
                 break;
                } 
                else
                {
                    break;
                }
               
            }
            if (stopInput ==1 && smax != Double.MinValue) 
            {
                
                Console.WriteLine("secondmax is {0}", smax);
            }
            else
            {
                Console.WriteLine("error");
            }
            
            Console.ReadLine();
            
        }
