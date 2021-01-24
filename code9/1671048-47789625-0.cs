    Console.WriteLine("Calculation of farm profit: ");
                            Console.Write("Enter price of milk: $");
                            double PriceOfMilk = double.Parse(Console.ReadLine());
                            double sumOfMilk = 0.0;
                            // loop through all livestocks (the array)
                            for (int i = 0; i < 20; i++)
                            {
                                sumOfMilk += animals[i].amountMilk;
                            }// end of for loop sumOfMilk
                            double yearIncome = sumOfMilk * 365 * PriceOfMilk; // total income
                            double cost = 0.0;
                            for (int i = 0; i < 20; i++)
                            {
                                cost += animals[i].costOfVaccination; // vaccination
                                cost += animals[i].costPerMonth * 12;
                            }// end of for loop Vaccination
                            double total = yearIncome - cost;
                            // Farms total profit for the year
                            Console.WriteLine("Farm profit: ${0}", total.ToString("0.00"));
                            Console.WriteLine();
                            Console.WriteLine("Press any key to return to the main menu...");
                            Console.ReadLine();
                            Console.Clear();
