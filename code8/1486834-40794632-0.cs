            Console.WriteLine("{0,-12} {1,-12} {2,-12}", "Diesel Car", "Petrol Car", "Alt. Fuel Car");
            Console.WriteLine("{0,-12} {1,-12} {2,-12}", "TC 49", "TC 48", "TC 59");
            Console.WriteLine("Enter Car Type (TC #): ");
            check = int.TryParse(Console.ReadLine(), out car);
            if (check)
            {
                if (car == 49)
                {
                    Console.WriteLine("Enter Licience length in months(6 or 12)");
                    length = int.Parse(Console.ReadLine());
                    if (length == 6)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 44;
                        }
                        else if (band == "A")
                        {
                            rate = 60.5;
                        }
                        else if (band == "B")
                        {
                            rate = 71.5;
                        }
                        else if (band == "C")
                        {
                            rate = 82.5;
                        }
                        else if (band == "D")
                        {
                            rate = 88;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D
                    }
                    else if (length == 12)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 80;
                        }
                        else if (band == "A")
                        {
                            rate = 110;
                        }
                        else if (band == "B")
                        {
                            rate = 130;
                        }
                        else if (band == "C")
                        {
                            rate = 150;
                        }
                        else if (band == "D")
                        {
                            rate = 160;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D 
                    }
                    else
                        Console.WriteLine("ERROR"); // error for length != 6 or 12
                }
                else if (car == 48)
                {
                    Console.WriteLine("Enter Licience length in months(6 or 12)");
                    length = int.Parse(Console.ReadLine());
                    if (length == 6)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 38.5;
                        }
                        else if (band == "A")
                        {
                            rate = 55;
                        }
                        else if (band == "B")
                        {
                            rate = 66;
                        }
                        else if (band == "C")
                        {
                            rate = 77;
                        }
                        else if (band == "D")
                        {
                            rate = 85.25;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D
                    }
                    else if (length == 12)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 70;
                        }
                        else if (band == "A")
                        {
                            rate = 100;
                        }
                        else if (band == "B")
                        {
                            rate = 120;
                        }
                        else if (band == "C")
                        {
                            rate = 140;
                        }
                        else if (band == "D")
                        {
                            rate = 155;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D 
                    }
                    else
                        Console.WriteLine("ERROR"); // error for length != 6 or 12
                }
                else if (car == 59)
                {
                    Console.WriteLine("Enter Licience length in months(6 or 12)");
                    length = int.Parse(Console.ReadLine());
                    if (length == 6)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 33;
                        }
                        else if (band == "A")
                        {
                            rate = 49.5;
                        }
                        else if (band == "B")
                        {
                            rate = 60.5;
                        }
                        else if (band == "C")
                        {
                            rate = 71.5;
                        }
                        else if (band == "D")
                        {
                            rate = 82.5;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D
                    }
                    else if (length == 12)
                    {
                        Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
                        band = Console.ReadLine();
                        if (band == "AA")
                        {
                            rate = 60;
                        }
                        else if (band == "A")
                        {
                            rate = 90;
                        }
                        else if (band == "B")
                        {
                            rate = 110;
                        }
                        else if (band == "C")
                        {
                            rate = 130;
                        }
                        else if (band == "D")
                        {
                            rate = 150;
                        }
                        else
                            Console.WriteLine("ERROR"); //error for band != AA,A,B,C or D 
                    }
                    else
                        Console.WriteLine("ERROR"); // error for length != 6 or 12
                }
                else
                    Console.WriteLine("ERROR"); // error for car number != 48,49 or 59
            }
            else
                Console.WriteLine("ERROR"); //error for car num != int
            Console.WriteLine(rate);
            Console.ReadLine();`
