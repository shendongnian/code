    public class AppDbContext : DbContext
    { 
      public DbSet<Item> Items { get; set; }
    }
    
    public class Data
    {
      public int Id { get; set; }
      public string Value { get; set; }
    }
    
    public class Item
    {
      public Item()
      {
      }
    
      public Item(IEnumerable<Data> data)
      {
        Data = data.ToList();
        using (var db = new AppDbContext())
        {
          db.Items.Add(this);
          db.SaveChanges();
        }
      }
    
      public override string ToString()
      {
        return Data != null ? $"Item:{Id}, Data:{string.Join(',', Data.Select(i => i.Value))}" : $"Item:{Id}, Data:None";
      }
    
      public int Id { get; set; }
      public ICollection<Data> Data { get; set; }
    }
...
    var i1 = new Item(new[] {new Data {Value = "1"}, new Data {Value = "2"}});
    var i2 = new Item(new[] {new Data {Value = "3"}, new Data {Value = "4"}});
    using (var db = new AppDbContext())
    {
      db.Items.Include(i => i.Data).ToList().ForEach(Console.WriteLine);
    }
