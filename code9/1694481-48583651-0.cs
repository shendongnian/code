    public class Layer
    {
        public IEnumerable<int> Data {get;set;}
        public int Height {get;set;}
        // ... implement other properties
    }
    
    public class MyObject
    {
        public int Height {get;set;}
        public bool Infinite {get;set;}
        public IEnumerable<Layer> Layers {get;set;}
        // ... implement other properties
    }
