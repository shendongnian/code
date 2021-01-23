    public class ManagedObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class RootObject
    {
        public List<ManagedObject> ManagedObjects { get; set; }
    }
    class MyComparer : IEqualityComparer<ManagedObject>
    {
        public bool Equals(ManagedObject x, ManagedObject y)
        {
            return x.Id.Equals(y.Id);
        }
        public int GetHashCode(ManagedObject obj)
        {
            return obj.Id.GetHashCode();
        }
    }
