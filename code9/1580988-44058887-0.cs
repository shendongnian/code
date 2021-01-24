            private void GoHere()
            {
                var list = new List<SortedList<string, string>>(); //List of Week
                list.Add(new SortedList<string, string>() {{"monday", "monday"}}); //Monday
                list.Add(new SortedList<string, string>() {{"tues", "monday"}}); //Tuesday
                list.Add(new SortedList<string, string>() {{"wed", "monday"}}); //Wednesday
                list.Add(new SortedList<string, string>() {{"thurs", "monday"}}); //Thursday
                list.Add(new SortedList<string, string>() {{"fri", "monday"}}); //Friday
                list.Add(new SortedList<string, string>() {{"sun", "monday"}}); //Saturday
                int? index = null;
    
                for (int i = 0; i < list.Count; i++)
                {
                    SortedList<string, string> sortedList = list[i];
                    if (sortedList.ContainsKey("wed"))
                    {
                        index = i;
                        break;
                    }
                }
                if (index.HasValue)
                {
                    list.RemoveAt(index.Value);
                }
            }
