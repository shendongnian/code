      using (StreamWriter sw = new StreamWriter("NewUser.txt", true))
    {
                    //loop for each user
                    for (iCount = 1; iCount <= iUserNumber; iCount++)
    
                        // enter details
                        Console.Write("Please Enter your Name" + iCount + ": ");
                sName = Console.ReadLine();
    
                // write to file
                sw.WriteLine(sName);
        }
