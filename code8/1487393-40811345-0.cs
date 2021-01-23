    var ctx = new Test();
    Expression<Func<Person, bool>> ageFilter = p => p.Age < 30;
    var filtered = ctx.People.AsExpandable()
        .Where(p => ageFilter.Invoke(p) && p.Name.StartsWith("J"));
    Console.WriteLine( $"{filtered.Count()} people meet the criteria." );
