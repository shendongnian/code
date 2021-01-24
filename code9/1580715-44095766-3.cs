            var source = new List<Record> { };
            var grouped = source
                .GroupBy(x => x.RequestID)
                //Select a key + only unique names
                .Select(x => new { Key = x.Key, Data = x.Select(r => r.PersonName).Distinct()})
                //Only groups with more than 1 entry
                .Where(x => x.Data.Count() > 1);
            //To loop through the data
            foreach(var group in grouped)
            {
                Console.WriteLine("Group: " + group.Key);
                foreach(var item in group.Data)
                {
                    Console.WriteLine("  " + item.PersonName);
                }
            }
    
