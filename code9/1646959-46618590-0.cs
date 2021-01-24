     //JObjectString is your string that contains the values
                JArray ValuesArray = JArray.Parse(JObjectString);
    
                Dictionary<string, int> SearchDict = new Dictionary<string, int>();
    
                //here the search term is the query from the user input
                string searchTerm = "govi";
    
                foreach (var rec in ValuesArray)
                {
                    SearchDict.Add(rec["name"].ToString(), Int32.Parse(rec["score"].ToString()));
                }
                //here is the result in javascript array format, return it
                string ResultString = JsonConvert.SerializeObject(SearchDict.Where(o => o.Key == searchTerm | o.Key.Contains(searchTerm)).
                    Select(o => o).OrderByDescending(o => o.Value).Take(10).Select(o => o));
