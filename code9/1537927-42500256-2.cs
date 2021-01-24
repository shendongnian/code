        static void Main(string[] args)
        {
            Dictionary<string, int> grades=new Dictionary<string, int>();
            grades["Miguel"] = 90;
            grades["Maddie"] = 85;
            grades["John"] = 70;
            grades["Isabella"] = 92;
            grades["Raul"] = 87;
            Console.WriteLine("Please enter your name: "); // Asking the user to type his/her name
            string studentName=Console.ReadLine(); //
            if (grades.ContainsKey(studentName))
            {
                Console.WriteLine(studentName+" your score was "+grades[studentName]);
            }
        }
