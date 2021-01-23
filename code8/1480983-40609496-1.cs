    public abstract class ObjectId
    {
        public abstract int Id { get; }
    }
    
    public class ObjectImpl : ObjectId
    {
        public override int Id
        {
            get { return 0; }
        }
    }
