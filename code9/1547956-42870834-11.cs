    // You define an enum with action and a dictionary with a collection of serialization methods.
    public enum SerializationAction {
    	ToBytes,
        ToObject	
    }
    
    // It can also be an enum, but it's easier to test with a collection of strings.
    public static readonly string[] SerializationKindList = new string[] {
    	"FirstKind",
    	"SecondKind"
    };
    
    // This generic class can have an implementation of all the handlers. Additional switching can be done by type, or reflection can be used to find properties for different classes and construct different classes.
    public class SerializationMethod {
    	public object ProcessByKind (string kindToUse, SerializationAction action, object objectToProcess) {
    		if (kindToUse == "FirstKind") {
    			if (action == SerializationAction.ToBytes) {
    			    return new byte[1];	
    			}
    			
    			return new SomeClass(); // These would need to be your hard implementations. Not clean.
    		} else {
    		    throw new NotImplementedException();	
    		}
    	}
    }
    
    // This struct type defines the serialization method and is required for the interface implementation
    public struct ByteSerialization
    {
    	public string SerializationTypeName { get; private set; }
    	public ByteSerialization(string kindToUse) {
    		if (!SerializationKindList.Contains(kindToUse)) {
    			throw new ArgumentException();
    		}
    			
    		SerializationTypeName = kindToUse;
    	}
    	public byte[] Deserialize(object objectToProcess) {
    	    var serializationMethod = new SerializationMethod();
    		return (byte[])serializationMethod.ProcessByKind(this.SerializationTypeName, SerializationAction.ToBytes, objectToProcess);
    	}
    	public object Serialize(byte[] byteArrayToProcess) {
    	    var serializationMethod = new SerializationMethod();
    		return serializationMethod.ProcessByKind(this.SerializationTypeName, SerializationAction.ToObject, byteArrayToProcess);
    	}
    }
    	
    
    // Interface for any class that needs to use generic serialization
    public interface IByteSerializable
    {
    	ByteSerialization serializationType { get; }
    }
    
    // Creating extension methods for the interface to make the life easier
    public static class IByteSerializableExtensions {
    	public static byte[] DeserializeObjectIntoBytes(this IByteSerializable objectToProcess) {
    		return objectToProcess.serializationType.Deserialize(objectToProcess);
    	}
    	public static void SerializeObjectFromBytes(this IByteSerializable objectToProcess, byte[] fromBytes) {
    		var someObjectData = objectToProcess.serializationType.Serialize(fromBytes);
    	}
    }
    
    
    // Abstract base class implementation with static readonly field.
    // Only downside - there is no way to enforce the config of this field in the constructor from the interface.
    // There also no way to make sure this field always gets set for other implementations of IByteSerializable
    public abstract class SomeBaseClass : IByteSerializable
    {
    	private static readonly ByteSerialization _serializationType = new ByteSerialization("FirstKind");
    
    	public ByteSerialization serializationType { get { return _serializationType; } }
    }
    
    public class SomeClass : SomeBaseClass {
    	
    }
    
    
    // And here's how one would use it. You will need to create a new object of the class before serializing from bytes.
    var someClass = new SomeClass();
    var bytes = someClass.DeserializeObjectIntoBytes();
    var someClass2 = new SomeClass();
    var byteArray = new byte[1];
    someClass2.SerializeObjectFromBytes(byteArray);
