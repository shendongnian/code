    var obj = JsonConvert.DeserializeObject<Container>(json);
    // ...
    public class Container
    {
        public HashSet<ManagedObject> ManagedObjects { get; set;}
    }
    public class ManagedObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        protected bool Equals(ManagedObject other)
        {
            return string.Equals(Id, other.Id);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ManagedObject)obj);
        }
        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
