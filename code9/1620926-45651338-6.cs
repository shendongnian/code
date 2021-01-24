    public interface IEntity<T>
    {
        Identity<T> Identity { get; }
    }
    public abstract class Identity<T> : IEquatable<Identity<T>>
    {
        private const string IdentityComponentDivider = ".";
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as Identity<T>;
            return other != null && GetIdentityComponents().SequenceEqual(other.GetIdentityComponents());
        }
        public override string ToString()
        {
            var id = string.Empty;
            foreach (var component in GetIdentityComponents())
            {
                if (string.IsNullOrEmpty(id))
                    id = component.ToString(); // first item, dont add a divider
                else
                    id += IdentityComponentDivider + component;
            }
            return id;
        }
        protected abstract IEnumerable<object> GetIdentityComponents();
        public override int GetHashCode()
        {
            return HashCodeHelper.CombineHashCodes(GetIdentityComponents());
        }
        public bool Equals(Identity<T> other)
        {
            return Equals(other as object);
        }
    }
