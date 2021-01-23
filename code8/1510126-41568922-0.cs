    public class Product
    {
        public async Task UpdateProduct(int productId, int UserId)
        {
            await Task.Run(() =>
            {
                //this will simulate your process
                Thread.Sleep(10000);
    
                //Category cat = new Category();
    
                //var catList = cat.GetCategory();
    
                //for (int i = 0; i < catList.count; i++)  //there are 3000 records here
                //{
                //    --------------some process--------
                //    -------------- - --------
                //}
            });            
        }
    
        public int XYZ()
        {
            return 1;
        }
    
        public int ABC()
        {
            return 1;
        }
    
        public int MNC()
        {
            return 1;
        }
    }
