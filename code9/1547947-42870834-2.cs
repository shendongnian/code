    // Let's define an interface for our serializable type of objects factory
    public interface IByteSerializableFactory<T>
    {
         T CreateFromBytes(byte[] objectDataToUse);
         byte[] CovertToBytes(T objectToConvert);
    }
    
    // Interface for any class that has a serialization factory
    public interface IByteSerializable
    {
        IByteSerializableFactory<T> GetFactory();
    }
    
    // Now a moment comes for us to have this kind of class. We need to build a factory first (because our interface requires a GetFactory() implementation.
    
    public class SomeBaseClassSerializationFactory : IByteSerializableFactory<SomeBaseClass>
    {
        SomeBaseClass CreateFromBytes(byte[] objectDataToUse) { //... }
        byte[] CovertToBytes(SomeBaseClass objectToConvert) { //... }
    }
    
    // We have a factory, let's implement a class.
    public abstract class SomeBaseClass : IByteSerializable
    {
        IByteSerializableFactory<SomeBaseClass> GetFactory() { return SomeBaseClassSerializationFactory; }
    }
