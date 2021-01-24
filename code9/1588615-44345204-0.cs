    public class ReflectionObject
    {
        public string Name
        {
            get {
                return this.GetType().Name;
            }
        }
    }
