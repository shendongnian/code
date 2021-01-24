    public class MyObject : IHasParent<MyObject>
    {
        readonly ChildCollection<MyObject, MyObject> childObjects;
        public MyObject() { this.childObjects = new ChildCollection<MyObject, MyObject>(this); }
        public string Name { get; set; }
        public IList<MyObject> ChildObjects { get { return childObjects; } }
        #region IHasParent<MyObject> Members
        [JsonIgnore]
        public MyObject Parent { get; private set; }
        public void OnParentChanging(MyObject newParent)
        {
            Parent = newParent;
        }
        #endregion
        // Added to suppress serialization of empty ChildObjects collections to JSON.
        public bool ShouldSerializeChildObjects() { return childObjects.Count > 0; }
    }
    public class RootObject
    {
        public RootObject() { this.Object = new List<MyObject>(); }
        public List<MyObject> Object { get; set; }
    }
