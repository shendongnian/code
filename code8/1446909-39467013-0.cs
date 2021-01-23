    class YourNewStuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zip { get; set; }
    }
    var newstuff2 = new List<YourNewStuff>();
    students.Select(x => newstuff2.Add(new YourNewStuff()
    {
        Id = x.Id,
        Name = x.Name,
        Zip = x.Adress.Zip
    });
