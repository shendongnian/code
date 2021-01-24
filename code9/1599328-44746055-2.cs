    public class User
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    public class UserComparer : IEqualityComparer<User>
    {
    	public bool Equals(User x, User y) => x.Id == y.Id;
    	public int GetHashCode(User obj) => base.GetHashCode();
    }
