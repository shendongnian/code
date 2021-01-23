    public class MyClassComparer : IEqualityComparer<UserRoleListViewModel>
    {
        public bool Equals(UserRoleListViewModelx, UserRoleListViewModely)
        {
            return x.ID == y.ID
                && x.FirstName.Equals(y.LastName, StringComparison.CurrentCultureIgnoreCase)
                && x.LastName.Equals(y.LastName, StringComparison.CurrentCultureIgnoreCase);
        }
    
        public int GetHashCode(UserRoleListViewModelobj)
        {
            int hash = 7;
            
        }
    }
