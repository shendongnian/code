    public class UserResourceParameters 
    {
      public string FirstName { get; set;}
      public string LastName { get; set; }
      [JsonIgnore]
      public string FullName { get => FirstName + " " + LastName; }
    }
