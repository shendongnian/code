    public static void SplitList()
        {
            var mainList = new List<string> { "Reset", "Set", "Test", "Test", "Reset", "Test", "Test" };
            List<List<string>> lstOutputLists = new List<List<string>>();
            List<string> tmp = new List<string>();
            foreach (var item in mainList)
            {
                if (item == "Reset")
                {
                    if (tmp.Count != 0)
                    {
                        lstOutputLists.Add(tmp);
                        tmp = new List<string>();    
                    }
                    
                }
                tmp.Add(item);
            }
            lstOutputLists.Add(tmp);
        }
