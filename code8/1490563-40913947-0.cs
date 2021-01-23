    Console.WriteLine("Please enter your first Name: ");
                String sFirstName = Console.ReadLine();
                String information = String.Empty;
                String append = String.Empty;
    
                while (true)
                {
                   
                    Console.Write("Please Enter your Name: ");
                    information = information + Console.ReadLine() + " ";
    
                    Console.Write("Please Enter the Name of your School: ");
                    information = information + Console.ReadLine() + " ";
    
                    if (information.Trim().Equals(""))
                    {
                        break;
                    }
    
                    Console.Write("Please Enter the Name of your Class: ");
                    information = information + Console.ReadLine() + "\t";
    
                    append = append + information;
                    information = String.Empty;
                    
    
                }
    
                String fileLocation = "C:...\\New Text Document.txt";
    
    
                using (StreamWriter sw = new StreamWriter(fileLocation))
                {
                    // write to file
                    sw.WriteLine(append);
                    Console.WriteLine("User data entered: ");
    
                }
    
               
