            class days
            {
                // numbers_of_days removed from class scope to constructor scope (to demonstrate var)
                // you can't use var to declare a private member
    //            private var not_valid = "compile error";
                private List<String> names_of_days;
    
                public days()
                {
                    // when using var to declare a variable, the type is derived by the compiler from the right side of the declaration
                    var numbers_of_days = new List<int>();
                    names_of_days = new List<string>{ "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
    
                    for (int i = 0; i < 31; i++)
                    {
                        numbers_of_days.Add(i);
                    }
                }
    
                public void print_days()
                {
                    foreach (string day in names_of_days)
                    {
                        Console.Write(" " + day.Substring(0, 3));
                    }
                    Console.WriteLine();
                }
            }
