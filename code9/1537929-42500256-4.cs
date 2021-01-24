        static void Main(string[] args)
        {
            var grades = new Dictionary<string, int>
                                {
                                      { "Miguel", 90 }
                                    , { "Maddie", 85 }
                                    , { "John", 70 }
                                    , { "Isabella", 70 }
                                    , { "Raul", 70 }
                                };
            Console.WriteLine("Please enter your name: "); // Asking the user to type his/her name
            string studentName=Console.ReadLine(); //
            if (grades.ContainsKey(studentName))
            {
                Console.WriteLine(studentName+" your score was "+grades[studentName]);
            }
        }
