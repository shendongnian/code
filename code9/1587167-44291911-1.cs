    public class Reference<T> where T : struct
    {
        public Reference(T t) {
            Value = t;
        }
        public T Value { get; set; }
    }
    class MyClass
    {
         MyClass(Reference<int> ref)
         {
              _ref = ref;
         }
         Reference<int> _ref;
    }
