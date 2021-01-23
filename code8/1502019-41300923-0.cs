            Dictionary<string,int> grades = new Dictionary<string, int>
            {
                { "Urdu", 0 },
                { "Maths", 0 },
                { "English", 0 },
                { "Biology", 0 },
                { "Chemistry", 0 },
                { "Islamiat", 0 },
                { "Physics", 0 },
                { "Computer", 0 },
                { "English Language", 0 },
                { "Pakistan Studies", 0 },
            };
            foreach (string grade in grades.Keys.ToArray())
            {
                Console.WriteLine(string.Format("Enter your {0} marks: ", grade));
                int mark;
                if (int.TryParse(Console.ReadLine(), out mark))
                    grades[grade] = mark;
            }
            int total = grades.Sum((g) => g.Value);
