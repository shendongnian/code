    public interface IImmutable {
        int Value { get; }
    }
    
    public class ClassWithImmutable{
        
		private Mutable _object;		
		public IImmutable Object { get { return _object; } }
    
        public ClassWithImmutable(){
            this._object = new Mutable();
            this._object.Value = 0;
        }
        private class Mutable : IImmutable {
            public int Value { get; set; }
        }
    }
    
    public class Demo{
        public static void Main(String[] args){
            ClassWithImmutable test = new ClassWithImmutable();
            IImmutable o = test.Object;
            o.Value = 1;    // fails
        }
    }
