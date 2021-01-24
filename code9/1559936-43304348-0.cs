        static void Main(string[] args)
        {
            Dictionary<string, List<int>> studentMarks = new Dictionary<string, List<int>>();
            string decision = "N";
            do
            {
                Console.WriteLine("Enter Student Name");
                string name = Console.ReadLine();
                //If you add the same key to dictionary, exception will be thrown
                if(studentMarks.ContainsKey(name))
                {
                    Console.WriteLine("The student already exists!");
                    continue;
                }
                Console.WriteLine("Enter the marks of " + name);
                List<int> marks = new List<int>();
                int subjectCount = 5;
                //Loop until your desired count of marks has been entered
                for (int i = 0; i < subjectCount; i++)
                {
                    string mark = Console.ReadLine();
                    if (string.IsNullOrEmpty(mark))
                    {
                        break;
                    }
                    int markInt = Convert.ToInt32(mark);
                    marks.Add(markInt);
                }
                studentMarks.Add(name, marks);
                Console.WriteLine("Do you want to add details of another student? (Y/N)");
                decision = Console.ReadLine();
            }
            //Keep doing until user wants to 
            while (decision == "Y");
        }
