    List<entry> filteredList = groupEntry.GroupBy(x => x.name)
            .Select(x => new entry
            {
                name = x.First().name,
                age = x.First().age,
                likes = String.Join(", ", x.Select(l=>l.likes))
            }).ToList();
    Console.WriteLine(String.Join("\n", filteredList)); 
