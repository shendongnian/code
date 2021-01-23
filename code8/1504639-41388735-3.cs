    // 1. implementation without the interface    
    public abstract class Base<T> {
        public abstract T Value {get; set;}
    }
    // 2. implementation with IBase
    public interface IBase {
        public dynamic Value {get; set;}
    }
    public abstract Base<T> : IBase {
        public abstract dynamic Value {get; set;}
    }
