    List<string> mylist = new List<string> { "app", "App", "zz", "zZ" };
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string key = string.Empty;
                foreach(string c in mylist)
                {
                    key = c.ToLower();
                    if(!dict.Keys.Contains(key))
                    {
                        dict.Add(key, c);
                    }
                }
                var t = dict.Values;
