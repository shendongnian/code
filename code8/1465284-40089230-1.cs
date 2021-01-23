    public class country
    {
        public string Name { get; set; }
        public string Covered { get; set; }
    }
    List<country> contries = new List<country>() { 
        new country(){ Name = "Siraj", Covered = "1"},
        new country(){ Name = "Kumail", Covered = "1"},
        new country(){ Name = "Ali", Covered = "1"},
        new country(){ Name = "Haider", Covered = "1"}
    };
     var query = (from x in contries
                  group x.Id by x.Name into g
                  select new { CustomName = string.Format("{0} ({1})", g.Key, g.Count()) }).ToList();
