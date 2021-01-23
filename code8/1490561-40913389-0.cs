       case 2: //enter new user
                //Enter new user information and add them to file
                Console.Write("Please Enter the number of users you wish to log: ");
                iUserNumber = Convert.ToInt32(Console.ReadLine());
                    //loop for each user
                    for (iCount = 1; iCount <= iUserNumber; iCount++)
                    {
                        // enter details
                        Console.Write("Please Enter your Name" + iCount + ": ");
                        sName = Console.ReadLine();
                        Console.Write("Please Enter the Name of your School: ");
                        sSchoolName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Please Enter the Name of your Class: ");
                        sClassName = Console.ReadLine();
                        // write to file
                        //open file for writing, in APPEND mode
                        using (StreamWriter sw = new StreamWriter("NewUser" +sName +".txt", true))
                        {
                            sw.WriteLine(sName);
                            Console.WriteLine();
                            sw.WriteLine(sSchoolName);
                            Console.WriteLine();
                            sw.WriteLine(sClassName);
                        }
                        Console.WriteLine("User data entered: ");
                    }
                }
