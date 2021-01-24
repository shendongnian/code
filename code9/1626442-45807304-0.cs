    namespace Sample {
        public interface IThing {
    
        }
    
        public class Type1 : IThing {
            public void Foo() { }
        }
    
        public class Type2 : IThing {
            public void Bar() { }
        }
    
        public class Program {
            static void Main(string[] args) {
                var list = new List<IThing> {
                    new Type1(),
                    new Type2()
                };
    
                foreach (var item in list) {
                    var t1 = item as Type1;
                    if (t1 != null) {
                        t1.Foo();
                    }
                }
            }
        }
    }
