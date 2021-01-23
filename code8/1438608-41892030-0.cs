    public class NotSerializableObject {
        public IEnumerable<Test> property {get; set;}
    }
    public interface AlsoNotSerializableObject {
        List<Test> property {get; set;}
    }
    public class SerializableObject {
        public List<Test> property {get; set;}
    }
