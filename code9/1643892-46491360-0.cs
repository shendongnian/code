    [DataContract]
    public class Person
    {
        [DataMember]
        private string _surname;
        public string Surname { get { return this._surname; } set { this._surname = value; } }
        public string Lastname { get { return this._surname; } set { this._surname = value; } }
    }
