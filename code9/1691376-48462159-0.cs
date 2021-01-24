            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate);
            StreamReader r = new StreamReader(fs);
            List<Dictionary<string,List<string>>> alldata = new List<Dictionary<string,List<string>>>();
            String[] lines = r.ReadToEnd().Split(new string[] { "\r\n" },StringSplitOptions.None);
            alldata.Add(new Dictionary<string, List<string>>());
            foreach (var item in lines)
            {
                if (item == "") { alldata.Add(new Dictionary<string, List<string>>()); continue; }
                var lst = alldata[alldata.Count - 1];
                string key = item.Split(':')[0];
                if (key.StartsWith("Useless")) continue;
                if (lst.ContainsKey(key))
                {
                    lst[key].Add(item.Split(' ')[1]);
                }
                else {
                    lst[key] = new List<string>();
                    lst[key].Add(item.Split(' ')[1]);
                }
            }
