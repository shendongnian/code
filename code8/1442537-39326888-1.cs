    public class AB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
    var abs = dbContext.Database.SqlQuery<AB>(@"SELECT A.Id, A.Name, B.Title
                                                FROM A JOIN B ON A.Id = B.Id");
    var a_and_bs = from ab in abs
                   select new
                   {
                       A = new A { ab.Id, ab.Name },
                       B = new B { ab.Title }
                   };
