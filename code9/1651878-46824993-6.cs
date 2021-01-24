    public abstract class BaseUIObject<T> where T : BaseObject
    {
        public T theObject { get; private set; }
        public virtual void Setup(T baseObject)
        {
            this.theObject = baseObject;
        }
    }
