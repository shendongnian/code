    public Dictionary<int, Product> GetProductsDict(DataTable dt)
     {
         Dictionary<int, Product> d1 = new Dictionary<int, Product>();
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             d1.Add((int)dt.Rows[i]["id"], GetProductByID((int)dt.Rows[i]["id"]));
         }
    
         return d1;
     }
    
     public Product GetProductByID(int id)
     {
         // do stuff to extruct product...
     }
