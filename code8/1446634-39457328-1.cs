       public class ProductDetails
       {
         public string id;
         public string description;
         public float rate;
         public override bool Equals(object obj)
         {
           if(obj is ProductDetails == null)
              return false;
          if(ReferenceEquals(obj,this))
              return true;
           ProductDetails p = (ProductDetails)obj;
           return description == p.description;
        }
      }
