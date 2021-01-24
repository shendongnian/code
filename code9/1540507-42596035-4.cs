    public class Product {
      public string ItemNumber { get; set; }
      public string Model { get; set; }
      public string Manufacturer { get; set; }
      public string Category { get; set; }
      public string SubCategory { get; set; }
      public Product(string iNum, string model, string manuf, string cat, string subCat) {
        ItemNumber = iNum;
        Model = model;
        Manufacturer = manuf;
        Category = cat;
        SubCategory = subCat;
      }
