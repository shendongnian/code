    public abstract class InventorAttribute {
        public string Name { get; set; }
        public InventorAttribute (string name) {
             Name = name;
        }
    }
    public class InventorAttribute<T> : InventorAttribute {
        public InventorAttribute (string name, T value) : base(name) {
        Value = value;
        }
    
        public T Value { get; set; }
    }
