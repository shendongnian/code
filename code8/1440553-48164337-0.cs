    public interface IMyTable
    {
      Guid Id { get; set; }
      string Name { get; set; }
    }
    
    public class MyTable : IMyTable
    {
      public string Id { get; set; }
      public string Name { get; set; }
      
      // use explicit implementation for Id
      Guid IMyTable.Id
      {
        get => Guid.Parse(this.Id);
        set => this.Id = value.ToString();
      }
    }
