    public int Id { get; set; }
    public string Name { get; set; }
    public override bool Equals(object obj) 
    {
       if (obj == null || GetType() != obj.GetType()) 
          return false;
       Car other = (Car)obj;
       return (Id == other.Id) && (Name == other.Name);
    }
    public override int GetHashCode() 
    {
       unchecked 
       {
           int hash = 19;
           hash = hash * 23 + Id;
           hash = hash * 23 + Name == null ? 0 : Name.GetHashCode();
           return hash;
       }
    }
