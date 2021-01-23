    public class Product
    {
          public Task UpdateProduct(int productId,int UserId)
          {
              Category cat = new Category();
    
              var catList = cat.GetCategory();
    
              for(int i=0; i< catList.count; i++)  //there are 3000 records here
              {
                 --------------some process--------
                 --------------- --------
              }
          }
    
    }
