    interface IInterface<T>
    {
        T GetComments(int id);
    }
    
    
    public class A: IInterface<WallGetObject>
    {
        public WallGetObject GetComments(int id)
        {
            WallGetObject item
            //... getting item
            return item
        }
    }
    
    public class B : IInterface<TopicFeedObject>
    {
         public TopicFeedObject GetComments(int id)
         {
            TopicFeedObject item
            //... getting item
            return item
         }
    }
