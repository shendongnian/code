    interface IComments {}
    class WallGetObject : IComments {}
    class TopicFeedObject : IComments {}
    interface IInterface
    {
        IComments GetComments(int id);
    }
    public class A: IInterface
    {
        public IComments GetComments()
        {
            WallGetObject item
            //... getting item
            return item
        }
    }
    
    public class B : IInterface
    {
         public IComments GetComments()
         {
            TopicFeedObject item
            //... getting item
            return item
        }
    }
    
