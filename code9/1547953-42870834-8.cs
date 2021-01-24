    // Let's define an interface for our serializable type of objects factory
    public interface IByteSerializableFactory<T>
    {
         T CreateFromBytes(byte[] objectDataToUse);
         byte[] CovertToBytes(T objectToConvert);
    }
    
    // Interface for any class that needs a serialization factory
    // This is not even necessary, but I like it to enforce people to implement simple methods that reference the factory.
    
    public interface IByteSerializable<T>
    {
        IByteSerializableFactory<T> GetFactory();
    }
    
    // Now a moment comes for us to have this kind of class. We need to build a factory first (because our interface requires a GetFactory() implementation. We can lose the IByteSerializable interface altogether, but then we lose a way to let people know which factory should be used.
    
    public class SomeBaseClassSerializationFactory : IByteSerializableFactory<SomeBaseClass>
    {
        public SomeBaseClass CreateFromBytes(byte[] objectDataToUse) { //...
    		return new SomeClass();
    	}
        public byte[] CovertToBytes(SomeBaseClass objectToConvert) { //...
    		return new byte[1];
    	}
    }
    
    // We have a factory, let's implement a class.
    
    public abstract class SomeBaseClass : IByteSerializable<SomeBaseClass>
    {
    	public virtual IByteSerializableFactory<SomeBaseClass> GetFactory() { 
    		return new SomeBaseClassSerializationFactory();												
    	}
    }
    	
    public class SomeClass : SomeBaseClass {
    	// Now we're independent. Our derived classes do not need to implement anything.
    	// If the way the derived class is serialized is different - we simply override the method
    }
