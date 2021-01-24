    values.Aggregate(new Tuple<int,int?>(0,null), (acc, e) => 
    {
        if(acc.Item2==null)
        {
            Console.WriteLine($"New record of {e.Value} on {e.Date.ToShortDateString()}");
            return new Tuple<int, int?>(1, e.Value);
        }
        else
        {
            if(e.Value!=acc.Item2.Value)
            {
                Console.WriteLine($"New record of {e.Value} on {e.Date.ToShortDateString()} (took {acc.Item1} days)");
                return new Tuple<int, int?>(1, e.Value);
            }
            else
            {
                return new Tuple<int, int?>(acc.Item1+1, acc.Item2);
            }
        }
    });
