        private static void DoIt()
        {
            Regex regex = new Regex("\\d*", RegexOptions.None);//we'll use this ro remove the existing numbers
            List<string> thelist = new List<string>() { "aa11", "ab2", "aa4", "df4" };//lets fake a list
            List<string> templist = new List<string>();//our temp storage
            Dictionary<string, int> counter = new Dictionary<string, int>();//our counting mechanism
            
            for (int i = 0; i < thelist.Count; i++)//loop through the original list of string
            {
                templist.Add(regex.Replace(thelist[i], ""));//strip the number and add it to the temp list
                if (!counter.ContainsKey(templist.Last()))
                {
                    counter.Add(templist.Last(), 0);//add the type to the counter dictionnary and set the "counter" to 0
                }
                
            }
            for (int i = 0; i < templist.Count; i++)//loop through the temp list
            {
                counter[templist[i]]++;//increment the counter of the proper type
                templist[i] = templist[i] + counter[templist[i]];//add the counter value to the string in the list
            }
            thelist = templist;//tadam
        }
