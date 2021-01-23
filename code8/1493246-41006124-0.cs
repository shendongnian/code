    static int GetIDInput()
        {
            int tempID = 0;
            bool taken = false;
            bool isInputValid = false;
            string lineValues;
            while (isInputValid == false)
            {
                Console.WriteLine("Please enter your desired ID number");
                tempID = Convert.ToInt32(Console.ReadLine());
                if (tempID.ToString().Length != 8)
                {
                    isInputValid = false;
                    Console.WriteLine("ID number must be 8 digits long.");
                }
                else if (tempID.ToString().Length == 8)
                {
                    isInputValid = true;
                }
                if (isInputValid) // this wont run if the input wasnt 8 characters, so the loop will restart
                {
                    using (StreamReader sr = new StreamReader("Stockfile.txt"))
                    {
                        while (sr.EndOfStream == false && taken != true)
                        {
                            lineValues = sr.ReadLine();
                            if (lineValues.Contains(tempID.ToString()))
                            {
                                taken = true;
                            }
                            else
                            {
                                taken = false;
                            }
                            if (taken == false)
                            {
                                
                            }
                            else if (taken == true)
                            {
                                Console.WriteLine("Sorry this ID is already taken, try again");
                                isInputValid = false;
                                // statements will lead us back to the while loop and taken == true so it will run again
                            }
                            }
                    }
                }
            }
            return tempID;
        }
