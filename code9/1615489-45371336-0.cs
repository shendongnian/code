    class Program
         {
           static void Main(string[] args)
            {
              using (var context = new MusicAlbumContext())
                 {
                      var count = context.Albums.Count();
                      Console.WriteLine(count);
                      context.Albums.Add(new Album() { Name = "best", Cost = 34.43m });
                     context.SaveChanges();
                     Console.WriteLine(count);
                     Console.Read();
        }
    }
}
      public  class MusicAlbumContext:DbContext
        {
          public MusicAlbumContext()
            : base("connectionstring")
        {
        }
        static MusicAlbumContext()
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MusicAlbumContext>());
    }
          public DbSet<Album> Albums { get; set; }
        }
     public   class Album
       {
        public string Name { get; set; }
        public decimal Cost { get; set; }
