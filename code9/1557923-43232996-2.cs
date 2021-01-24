    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "person1")]
        public Person[] Person1 { get; set; }
        [DataMember(Name = "person2")]
        public Person[] Person2 { get; set; }
        [DataMember(Name="person3")]
        public Person[] Person3 { get; set; }
    }
    [DataContract]
    public class Person
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "age")]
        public int Age { get; set; }
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "hobby")]
        public string Hobby { get; set; }
    }
