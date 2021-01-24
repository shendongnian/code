    public abstract class ClonableBase<T>
    {
        public T Clone()
        {
            T clone = (T)MemberwiseClone();
            Initialize(clone)
            return clone;
        }
        protected virtual void Initialize(T clone)
        {
        }
    }
