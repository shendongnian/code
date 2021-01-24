        var final33 = new List<List<Movie>>();
        ....
        for (int i = 0; i < acd.Count(); i++)
        {
            final33.Add(final1.Where(c => c.Id == acd[i]).ToList());
        }
