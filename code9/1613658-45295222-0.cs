                KeyValuePair<string, int> kvp = new KeyValuePair<string, int>();
                IList < KeyValuePair < string, int> >  list= new 
                List<KeyValuePair<string, int>>();
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 25", 10));
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 24", 3));
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 23", 7));
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 22", 4));
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 21", 2));
                list.Add(new KeyValuePair<string, int>("2017 - 7 - 25", 5));
                list.Add(new KeyValuePair<string, int>("2017 - 6 - 26", 8));
                list.Add(new KeyValuePair<string, int>("2017 - 5 - 26", 18));
    
    
                TimeSpan interval = TimeSpan.FromDays(5);     
                var output=list.GroupBy(x => DateTime.Parse(x.Key).Ticks / interval.Ticks).Select((n) => new { GroupId = new DateTime(n.Key * interval.Ticks), Sum= n.Sum(x => x.Value) });
