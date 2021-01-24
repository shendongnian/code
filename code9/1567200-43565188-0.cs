    class Customer {
      public string Name { get; set; }
      public string AccountType { get; set; }
      public int ID { get; set; }
      public Customer(string inName, string actType, int inID) {
        Name = inName;
        AccountType = actType;
        ID = inID;
      }
      public string GetName() {
        return Name;
      }
      public override string ToString() {
        return "Name: " + Name + " AccountType: " + AccountType + " ID: " + ID;
      }
    }
