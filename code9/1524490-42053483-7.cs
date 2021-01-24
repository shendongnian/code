            int removeAt = 7; //or any thing you want
            int linesToRemove = 3; //or any thing you want
            string s = System.IO.File.ReadAllText("Test.txt");
            List<string> arr = s.Split(new char[] { '\n' }).ToList();
            List<int> realBareRows = new List<int>();
            for (int i = 0; i < arr.Count; i++)
            {
                if (string.IsNullOrEmpty(arr[i].Replace("\r", "")))
                    realBareRows.Add(i);
            }
            List<string> newArr = s.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (int j in realBareRows)
                newArr.Insert(j, "\n");
            for (int i = 0; i < linesToRemove; i++)
                newArr.RemoveAt(removeAt);
            string result = "";
            foreach (string str in newArr)
            {
                result += str + System.Environment.NewLine;
            }
            System.IO.File.WriteAllText("Test.txt", result);
