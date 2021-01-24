    public class Clients : IEquatable<Clients>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Clients(string e, string n)
        {
            Email = e;
            Name = n;
        }
        public override bool Equals(object obj)
        {
            return obj is Clients && this.Equals((Clients)obj);
        }
        public bool Equals(Clients other)
        {
            return Email == other?.Email == true
                && Name == other?.Name == true;
        }
        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + (Email?.GetHashCode() ?? 0);
                hash = hash * 23 + (Name?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
