    public class Member
    {
        public int Id { get; set; }
        public string Year { get; set; }
    }
    var items = (new List<Member>() {
        new Member() { Id=1, Year="2010" },
        new Member() { Id=2, Year="2010" },
        new Member() { Id=1, Year="2008" },
        new Member() { Id=1, Year="2009" }
    }).ToArray();
    // Group everythnig by year, then only keep the highest id
    var firstFiltered = items
        .GroupBy(
            x => x.Year,
            x => x.Id,
            (year, ids) => new Member()
                            {
                                Id = ids.Last(),
                                Year = year
                            });
    var secondFiltered = firstFiltered
        // Only keep years before 2010
        .Where(x => String.Compare(x.Year, "2010") == -1)
        // Then order by Id then Year
        .OrderBy(x => x.Id)
        .ThenBy(x => x.Year)
        // And only keep the last/most recent year
        .GroupBy(
            x => x.Id,
            x => x.Year, 
            (id, years) => new Member() 
                            {
                                Id = id,
                                Year = years.Last()
                            });
