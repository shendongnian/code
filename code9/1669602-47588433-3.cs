            static void Main(string[] args)
            {
                Livestock[] animals = new Livestock[20];
                int counter = 0;
                string myLine;
                string[] words;
                TextReader tr = new StreamReader("S:/BIT694/livestock.txt");
    
                while ((myLine = tr.ReadLine()) != null)
                {
                    words = myLine.Split(',');
                    int ID = int.Parse(words[0]);
                    string LivestockType = words[1];
                    int YearBorn = int.Parse(words[2]);
                    double CostPerMonth = double.Parse(words[3]);
                    double CostOfVaccination = double.Parse(words[4]);
                    double AmountMilk = double.Parse(words[5]);
    
                    if (LivestockType == "Cow")
                    {
                        Cow newCow = new Cow(ID, "Cow", YearBorn, CostPerMonth, CostOfVaccination, AmountMilk);
                        animals[counter] = newCow;
                    }
                    else if (LivestockType == "Goat")
                    {
                        Goat newGoat = new Goat(ID, "Goat", YearBorn, CostPerMonth, CostOfVaccination, AmountMilk);
                        animals[counter] = newGoat;
                    }
                    counter++;
                }
                int choice;
    
                for (;;)
                {
                    do
                    {
                        Console.WriteLine("--------Menu--------"); // The menue Title
                        Console.WriteLine();
                        Console.WriteLine("1) Display livestock information by ID"); // Display the livestock by ID number
                        Console.WriteLine("2) Display cow that produced the most milk"); // Displays the cow that porduces the most milk
                        Console.WriteLine("3) Display goat that produced the least amount of milk"); // Displays the goat that produces the least amount of milk
                        Console.WriteLine("4) Calculate farm profit"); // Calculates the farm profit
                        Console.WriteLine("5) Display unprofitable livestock"); // Displays the unprofitable livestock
                        Console.WriteLine("0) Exit"); // Exits the program
                        Console.WriteLine();
                        Console.Write("Enter an option: ");
    
                        choice = int.Parse(Console.ReadLine());
                    } while (choice < 0 || choice > 5);
    
                    if (choice == 0) break;
    
                    Console.WriteLine("\n");
    
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter livestock ID: ");
                            int input = int.Parse(Console.ReadLine());
                            Livestock livestock = animals.Where(animal => animal.ID == input).ToList().FirstOrDefault();
                            if (livestock != null)
                            {
                                livestock.displayInfo();
                            }
                            else
                            {
                                Console.WriteLine("ID not found"); // Invaild ID
                            }
    
                            break;
                        case 2:
                            Console.WriteLine("Cow that produced the most Milk:");
                            Livestock maxCow = animals.Where(animal => animal.LivestockType == "Cow").OrderByDescending(animal => animal.AmountMilk).FirstOrDefault();
                            if (maxCow != null)
                                maxCow.displayInfo();
                            else
                                Console.WriteLine("No cow");
                            break;
                        case 3:
                            Console.WriteLine("Goat that produced the least amount of milk:");
                            break;
                        case 4:
                            Console.WriteLine("Calculateion of farm profit:");
                            break;
                        case 5:
                            Console.WriteLine("Livestock that are not profitable:");
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("The Option that you have entered is invalid please try again");
    
                            break;
                    }
                    Console.ReadLine();
                }
            }
        }
    
        public class Livestock
        {
            public int ID { get; set; } //ID Number of livestock
            public string LivestockType {get; set;} //Value is either "Cow" or "Goat"
            public int YearBorn  { get; set; } //Year of birth with format YYYY (i.e. 2014)
            public double CostPerMonth  { get; set; }//The cost per month
            public double CostOfVaccination { get; set; } //Annual vaccination cost
            public double AmountMilk { get; set; } //The amount of milk produced per day in liters
    
            public Livestock(int ID, string LivestockType, int YearBorn, double CostPerMonth, double CostOfVaccination, double AmountMilk)
            {
                this.ID = ID;
                this.LivestockType = LivestockType;
                this.YearBorn = YearBorn;
                this.CostPerMonth = CostPerMonth;
                this.CostOfVaccination = CostOfVaccination;
                this.AmountMilk = AmountMilk;
    
            }
    
            public void displayInfo()
            {
                Console.WriteLine();
                Console.WriteLine(LivestockType);
                Console.WriteLine("ID:\t\t\t {0}", iD);
                Console.WriteLine("Year Born:\t\t {0}", YearBorn);
                Console.WriteLine("Cost Per Month\t\t ${0}", CostPerMonth);
                Console.WriteLine("Cost Of Vaccination:\t ${0}", CostOfVaccination);
                Console.WriteLine("Milk Per Day:\t\t {0}liters", AmountMilk);
                return;
            }
        }
