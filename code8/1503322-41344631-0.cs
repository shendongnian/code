    public class ProductResult  : IEquatable<ProductResult> // we have to tell C# compiler how to check if the objects are different from one another
    {
       public string Name { get; set; }
       public string Category { get; set; }
       public string Supplier { get; set; }
    
       public bool Equals(ProductResultother)
                {
                    if (other == null)
                        return false;
    
                    return (Category == other.Category) 
                           && Supplier  == other.Supplier)
                           && Name  == other.Name ); // optionally do an .Equals() to make this case-insensitive (check for nulls first if you do this!)
                }
    }
