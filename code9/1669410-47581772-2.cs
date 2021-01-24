    public class SomethingWithId {
        public int Id { get; set; }
    }
    // you have no idea what that is at runtime
    object something = new List<SomethingWithId>() {new SomethingWithId() {Id = id}};
