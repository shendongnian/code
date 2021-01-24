    string s = System.IO.File.ReadAllText("Test.txt");
            List<string> arr = s.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < 5; i++)
                arr.RemoveAt(0);
            string result="";
            foreach (string str in arr)
            {
                result += str + System.Environment.NewLine;
            }
            System.IO.File.WriteAllText("Test.txt", result);
