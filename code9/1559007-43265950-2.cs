    public class Base<T>
        where T : Base<T>
    {
        private List<string> attributes = new List<string>();
        public T WithAttributes(params string[] attributes)            
        {
            this.attributes.AddRange(attributes);
            return this as T;
        }
    }
    public class Derived : Base<Derived>
    {
    }
