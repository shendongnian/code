    public interface IByteSerializable
    {
        byte[] SerializableByteObject { get; }
    }
    
    public abstract class ByteSerializable : IByteSerializable
    {
        public byte[] SerializableByteObject { get; }
        protected virtual byte[] GetBytes() {
            return SerializableByteObject;
        }
        public abstract IByteSerializable GetObject();
        //{    // You can make this method virtual and use Impl method:
               // GetObjectImpl(SerializableByteObject);
        //}
        protected internal IByteSerializable GetObjectImpl(byte[] bytes) {
            // If you need a default implementation (GetObject() should be protected virtual then)
    		// return IByteSerializable...;
        }
    }
