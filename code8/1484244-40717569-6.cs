    //Care of naming !
                // string[] names - its a sort of collection of names so dont call it name.
                // name would be ONE item of that array
                //I recommend using List<sting> / List<double> here !
                List<string> employees = new List<string>();
                List<double> wages = new List<double>();
                //Or way better => Dictionairy<string, double>(),
                //A Dictionairy has a Key (unique) and a correlating value 
                Dictionary<string, double> EmployeeWages = new Dictionary<string, double>();
                int employeesToAdd = 0;
                try
                {
                    Console.Write("How many employees would you like to add ?");
                    employeesToAdd = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Write($"Error: {ex.Message}");
                    return;
                }
                //We reach this line only if employeesToAdd has a value !
                for (int i = 0; i < employeesToAdd; i++)
                {
                    EmployeeWages.Add(GetUserInput_String("Please enter name: "), GetUserInput_Double("Please enter your wage: "));
                }
                PrintResult(EmployeeWages);
