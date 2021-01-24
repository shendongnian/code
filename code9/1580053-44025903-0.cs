    class abc {
      public string firstName { get; set; }
      public string lastName { get; set; }
      public override bool Equals(object obj) {
        abc other = obj as abc;
        if (object.ReferenceEquals(null, other))
          return false;
        else
          return string.Equals(firstName, other.firstName) &&
                 string.Equals(lastName, other.lastName);
      }
      public override int GetHashCode() {
        return (lastName == null ? 0 : lastName.GetHashCode()) ^ 
               (firstName == null ? 0 : firstName.GetHashCode());
      }
    }
    ....
    var a1 = new abc();   
    var a2 = new abc();  // object of same class
    if (a1 == a2) // now it'll return true
    {
       // some code here
    }
