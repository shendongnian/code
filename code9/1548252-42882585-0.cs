    public class UserPriviledge { //... your db-defined privileges  }
    
    public interface IFamilyProperty<T>
    {
        public string PropertyName { get; }
        public T PropertyValue { get; }
        public List<UserPriviledge> ReadPriviledges { get; }
        public bool IsReadOnly { get; }
    }
    
    public class FamilyName : IFamilyProperty<string>
    {
        public static string PropertyName => "Name";
        public string PropertyValue { get; }
        public List<UserPriviledge> ReadPriviledges { get; }
        public bool IsReadOnly { get; private set; }
    
        public FamilyName(string familyName) {
            this.PropertyValue = familyName;
            this.ReadPriviledges.Add(someUserPrivilege);
            this.IsReadOnly = false;
        }
    
        public void MakeReadOnly() {
            this.IsReadOnly = true;
        }
    }
    
    public class Family
    {
         public int Id { get; }
         public List<IFamilyProperty> LimitedProperties { get; }
    }
