    public class MyClassComparer : IEqualityComparer<UserRoleListViewModel>
    {
        public bool Equals(UserRoleListViewModel x, UserRoleListViewModel y)
        {
            return x.ID == y.ID
                && x.FirstName.Equals(y.FirstName, StringComparison.CurrentCultureIgnoreCase)
                && x.LastName.Equals(y.LastName, StringComparison.CurrentCultureIgnoreCase);
             // continue to add all the properties needed in comparison
        }
    
        public int GetHashCode(MyClass obj)
        {
            StringComparer comparer = StringComparer.CurrentCultureIgnoreCase;
            int hash = 17;
            hash = hash * 31 + obj.ID.GetHashCode();
            hash = hash * 31 + (obj.FirstName == null ? 0 : comparer.GetHashCode(obj.FirstName));
            hash = hash * 31 + (obj.LastName == null ? 0 : comparer.GetHashCode(obj.LastName));
            // continue all fields
            return hash;
        }
    }
