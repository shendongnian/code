    public float hoursWorked()
        {
            string yesno = "";
            List<float> hWorked = new List<float>();
            float hours = 0;
            do
            {
                try
                {
                    Console.Write("Please enter hours worked: ");
                    hours = float.Parse(Console.ReadLine());
                    if (hours > 0)
                    {
                        Console.WriteLine("Hours added");
                        hWorked.Add(hours);
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid hours");
                    }
                    Console.Write("Do you want to add more hours? Please state Yes or No: ");
                    yesno = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (yesno != null && yesno.ToUpper() != "NO");
                
            return hWorked.Sum();
        }
