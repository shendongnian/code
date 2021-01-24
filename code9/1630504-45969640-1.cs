First you should make the mutable properties private set;, the constructor accept initial state, and consider making EditInfo an instance method. This more or less treats each Employee like a database record with access control. This creates a clearer relationship.
    public class Employee
    {
        public Employee(string firstName, string lastName, bool isManager, ...)
        {
            FirstName = firstName;
            LastName = lastName;
            IsManager = isManager;
            // remaining properties...
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsManager { get; private set; }
        // remaining properties...
        public void Edit(ref Employee requester)
        {
            if (requester.IsManager) {
                // query input from the user, make changes, and notify the user.
            } else {
                // notify the user that he doesn't have permission to edit this employee. 
            }
        }
    }
