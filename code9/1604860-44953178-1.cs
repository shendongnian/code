    [DataContract]
    public class User {
        [DataMember(Name="Id")]
        public int Id { get; set; }
        [DataMember(Name="Name")]
        public string Name { get; set; }
        [DataMember(Name="Age")]
        public int Age { get; set; }
    }
    [DataContract]
    public class Paging {
        [DataMember(Name="TotalPages")]
        public int TotalPages { get; set; }
        [DataMember(Name="CurrentPage")]
        public int CurrentPage { get; set; }
    }
    [DataContract]
    public class UserResponse {
        [DataMember(Name="Results")]
        public List<User> Results { get; set; }
        [DataMember(Name="Paging")]
        public Paging Paging { get; set; }
    }
