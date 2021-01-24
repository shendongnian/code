    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            this.CreateHook()
                .OnSave<Item>()
                .Do(i=> i.LastUpdated = DateTime.Now)
         }
     }
