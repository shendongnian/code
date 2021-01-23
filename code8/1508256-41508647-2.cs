    class MyClass
    {
        public int Id { get; set; }
        private string _NameSurname;
        public string NameSurname { get { return _NameSurname; } set { _NameSurname = value.Trim(); } }
        private string _EmailAddress;
        public string EmailAddress { get { return _EmailAddress; } set { _EmailAddress = value.Trim(); } }
        public DateTime DateCreated { get; set; }
        public string GetJSON()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
