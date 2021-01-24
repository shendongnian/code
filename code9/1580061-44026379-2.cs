     public class Category
     {
         public int Id { get; set; }
         public bool Status { get; set; }
         public List<Product> Products { get; set; }
         public Category(int id, bool status)
         {
             this.Id = id;
             this.Status = status;
          }
     }
