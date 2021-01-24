    [DataContract]
    public class User {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
    }
    [DataContract]
    public class Paging {
        [DataMember]
        public int TotalPages { get; set; }
        [DataMember]
        public int CurrentPage { get; set; }
    }
    [DataContract]
    public class UserResponse {
        [DataMember]
        public List<User> Results { get; set; }
        [DataMember]
        public Paging Paging { get; set; }
    }
