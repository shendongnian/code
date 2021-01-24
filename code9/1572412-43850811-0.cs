    public class MyDbContext: DbContext 
    {
        public virtual DbSet<MyItem> Items {get; set;}
        
        public virtual AddOrUpdate<T>(T item)
        {
             if(typeof(T) == typeof(MyItem))
             {
                 Items.AddOrUpdate(item as MyItem)
             }
        }
    }
