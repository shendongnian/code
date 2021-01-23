    public enum PrivilegedAccounts
    {
        User = 1,
        Service = 16,
        Admin = 64,
        Other = 1040,
        Executive = 2048
    }
     
     var values = Enum.GetValues(typeof(PrivilegedAccounts));
     SomeEnum randomValue = (PrivilegedAccounts)values[Random.Range(1, values.Length)]; //Start from 1 instead of 0 to avoid User
