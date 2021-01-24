    public class TransformFactory
    {
        public Transformer<T> GetTransformer<T>(T item)
        {
            if (item is Template1)
                return new Transformer1();
            else if (item is Template2)
                return new Transformer2();
            // ...
        }
    }
