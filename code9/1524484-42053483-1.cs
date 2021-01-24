            int removeAt = 2; //or any thing you want
            int linesToRemove = 5; //or any thing you want
            string s = System.IO.File.ReadAllText("Test.txt");
            List<string> arr = s.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < linesToRemove; i++)
                arr.RemoveAt(removeAt);
            string result = "";
            foreach (string str in arr)
            {
                result += str + System.Environment.NewLine;
            }
            System.IO.File.WriteAllText("Test.txt", result);
