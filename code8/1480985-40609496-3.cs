    public abstract class ObjectId
    {
        // Or as auto-propert `public virtual int Id { get; private set; }`.
        public abstract int Id { get; }
    }
    
    public class ObjectImpl : ObjectId
    {
        public override int Id
        {
            get { return 0; }
        }
    }
