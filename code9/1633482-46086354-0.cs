    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>(new ObjectReferenceEqualityComparer());
        }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    [Serializable]
    public sealed class ObjectReferenceEqualityComparer : IEqualityComparer<object>
    {
        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }
        int IEqualityComparer<object>.GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }
    }
