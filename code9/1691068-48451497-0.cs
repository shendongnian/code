    public abstract class ClonableBase<T>
    {
        public T Clone()
        {
            return (T)this.MemberwiseClone();
        }
    }
    public class RealClass : ClonableBase<RealClass> { }
