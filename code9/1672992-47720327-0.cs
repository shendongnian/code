    public abstract class Transformer<T>
        where T : Template
    {
        public abstract void Transform(T item);
    }
