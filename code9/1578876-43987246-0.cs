    var result = events.OrderByDescending(x => x.EventDate).ThenByDescending(x => x.AccessTime).GroupBy(x=>x.EventDate).Select(x=>x.First());
    foreach (Event a in result)
    {
                Console.WriteLine(a.Id + "\t" + a.Emp + "\t" + a.EventDate + "\t" + a.AccessTime);
    }
