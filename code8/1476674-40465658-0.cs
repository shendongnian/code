    class User: IEquatable<User>
    {
        public int Id{ get; set; }
        public string UserName { get; set; }
    
        public bool Equals(User other)
        {
            return Id == other.Id;
        }
    
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
