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
                 where x.Covered == "1"
                 select new { Name = x.Name, Coverd = x.Covered, Custom = string.Format("{0} ({1})", x.Name, x.Covered) }).ToList();
