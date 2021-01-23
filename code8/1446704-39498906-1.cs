    public interface IUserAccountService // No repository!
    {
        UserAccount Find(string email, string password);
        bool CheckDuplicate(string email);
    }
