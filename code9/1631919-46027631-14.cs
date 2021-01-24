          static void Main(string[] args)
        {
            
            List<Employee> listOfEmploies = new List<Employee>
            {
                new Employee { FirstProp = 1, SecondProp = "SomeText01" },
                new Employee { FirstProp = 2, SecondProp = "SomeText02" }
            };
           EmployeeReflection(listOfEmploies);
            Console.ReadLine();
        }
