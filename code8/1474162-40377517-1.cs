      var list = new List<string>();
            var text = File.ReadAllLines("1.txt");
            foreach (var s in text)
            {
                if (s.Contains("Description"))
                {
                    var desc = s.Substring(s.IndexOf("=") + 1);
                    list.Add(desc);
                }
            }
