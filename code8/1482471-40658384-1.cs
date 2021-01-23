            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 1);
            dict.Add(1, 2);
            dict.Add(2, 3);
            Dictionary<int, int> dictOutput = new Dictionary<int, int>();
            foreach (KeyValuePair<int,int> item in dict)
            {
                dictOutput.Add(item.Key, item.Value + 1);
            }
            dict.Dispose();
