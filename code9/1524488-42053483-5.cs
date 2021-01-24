            int removeAt = 7; //or any thing you want
            int linesToRemove = 3; //or any thing you want
            string s = System.IO.File.ReadAllText("Test.txt");
            List<string> arr = s.Split("\n".ToCharArray()).ToList();
            
            for (int i = 0; i < linesToRemove; i++)
                arr.RemoveAt(removeAt);
            string result = "";
            foreach (string str in arr)
            {
                result += str;
            }
            System.IO.File.WriteAllText("Test.txt", result);
