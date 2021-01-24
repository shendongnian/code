    public class CarModel
    {
      public int CarModelId { get; set; }
      public string Name { get; set; }
      public virtual CarFactory CarFactory { get; set; }
    }
    public class CarFactory
    {
      public int CarFactoryId { get; set; }
      public string Name { get; set; }
      public virtual List<CarModel> ModelsMade { get; set; }
    }
