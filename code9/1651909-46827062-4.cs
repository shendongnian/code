       static void Main(string[] args)
        {
            try
            {
                StringBuilder runningtotal = new StringBuilder();
                int count = 0;
                double total = 0.0;
                double average = 0.0;
                double number;
                Console.WriteLine("Enter the set of scores (enter 0 to indicate end of set)");
                number = double.Parse(Console.ReadLine());
                runningtotal.Append(number.ToString());
                while (number != 0)
                {
                    total += number;
                    count++;
                    number = double.Parse(Console.ReadLine());
                    if (number!=0)
                    {
                        runningtotal.Append("+" + number.ToString());
                    }
                
                }
                if (count != 0)
                    average = total / count;
                Console.Beep(20000, 2000);
                Console.WriteLine("The user has entered {0} scores.", count);
                Console.WriteLine("The sum of scores entered = {0}", total);
                Console.WriteLine("The average of scores entered = {0}", average);
                Console.WriteLine(runningtotal);
                string[] inputs = runningtotal.ToString().Split('+');
                Console.WriteLine("Running total");
                int temp=0;
                for (int i = 0; i <inputs.Length; i++)
                {
                    if (temp==0)
                    {
                        Console.WriteLine("{0} = {1}",inputs[i],inputs[i]);
                        temp = Convert.ToInt32(inputs[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0} = {1}", inputs[i], Convert.ToInt32(inputs[i]) + temp);
                        temp = Convert.ToInt32(inputs[i]) + temp;
                    }
                   
     
                   
                }
              
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
