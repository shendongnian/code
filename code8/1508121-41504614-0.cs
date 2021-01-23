    public class CategoryLookup
    {
        
        public CategoryLookup(int catId)
        {
            this.CategoryId = catId;
        }
     
        public int CategoryId
        {
            get; private set;
        }
        
        public int RequiredAmount
        {
            get; private set; 
        }
        
        public void Increment()
        {
            this.RequiredAmount++;
        }
    }
