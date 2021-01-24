    // Let's define an interface for our serializable type of objects factory
    public interface IByteSerializableFactory
    {
         T CreateFromBytes(byte[] objectDataToUse);
         byte[] CovertToBytes(T objectToConvert);
    }
    
    // Interface for any class that needs a serialization factory
    // This is not even necessary, but I like it to enforce people to implement simple methods that reference the factory.
    public interface IByteSerializable
    {
        T GetFactory() where T : IByteSerializableFactory;
    }
    
    // Now a moment comes for us to have this kind of class. We need to build a factory first (because our interface requires a GetFactory() implementation. We can lose the IByteSerializable interface altogether, but then we lose a way to let people know which factory should be used.
    
    public class SomeBaseClassSerializationFactory : IByteSerializableFactory
    {
        SomeBaseClass CreateFromBytes(byte[] objectDataToUse) { //... }
        byte[] CovertToBytes(SomeBaseClass objectToConvert) { //... }
    }
    
    // We have a factory, let's implement a class.
    public abstract class SomeBaseClass : IByteSerializable
    {
        SomeBaseClassSerializationFactory GetFactory() { return SomeBaseClassSerializationFactory; }
    }
