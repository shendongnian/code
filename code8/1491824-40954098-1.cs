    public class DeepCloneableList<T> : List<T>, ICloneable where T : ICloneable
    {
        public object Clone() {
            var clone = new DeepCloneableList<T>();
            clone.AddRange(this.Select(x => (T)x.Clone()));
            return clone;
        }
    }
