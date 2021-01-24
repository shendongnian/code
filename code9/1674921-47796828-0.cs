    class Product
    {
      public int ID;
      public string Name;
      public string Description;
    }
    class Order
    {
      public int ProductID;
      public DateTime DeliveryDate;
    }
    class Program
    {
      static void Main(string[] args)
      {
         Product[] proTestData = new Product[]
         {
            new Product() {ID=1, Name="Widget", Description="Banded bulbous snarfblat"},
            new Product() {ID=2, Name="Gadget", Description="Hitchhiker's guide to the galaxy"}
         };
         Order[] ordTestData = new Order[]
         {
            new Order() {ProductID=1, DeliveryDate=new DateTime(2017,12,14)},
            new Order() {ProductID=1, DeliveryDate=new DateTime(2017,12,20)},
            new Order() {ProductID=2, DeliveryDate=new DateTime(2017,12,23)},
            new Order() {ProductID=2, DeliveryDate=new DateTime(2017,12,22)},
            new Order() {ProductID=2, DeliveryDate=new DateTime(2017,12,21)},
            new Order() {ProductID=1, DeliveryDate=new DateTime(2017,12,18)}
         };
         var rows =
            (from p in proTestData
             join o in ordTestData
             on p.ID equals o.ProductID
             group o.DeliveryDate by p into grp
             select new {
                grp.Key.ID,
                grp.Key.Name,
                grp.Key.Description,
                minDate = grp.Min()}
            ).ToList();
         foreach (var row in rows)
         {
            Console.WriteLine("{0}: {1}", row.Name, row.minDate);
         }
      }
    }
