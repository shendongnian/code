    public class MyClassComparer : IEqualityComparer<UserRoleListViewModel>
    {
        public bool Equals(UserRoleListViewModel x, UserRoleListViewModel y)
        {
            return x.ID == y.ID
                && x.FirstName.Equals(y.LastName, StringComparison.CurrentCultureIgnoreCase)
                && x.LastName.Equals(y.LastName, StringComparison.CurrentCultureIgnoreCase);
             // continue to add all the properties needed in comparison
        }
    
        public int GetHashCode(UserRoleListViewModelx obj)
        {
           int hash = 17; 
           hash = hash * 31 + ID.GetHashCode();   
           hash = hash * 31 + FirstName.GetHashCode(); 
           hash = hash * 31 + LastName.GetHashCode();
           // continue all fields
        
           return hash;
        }
    }
