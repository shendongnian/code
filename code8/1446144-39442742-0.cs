    public virtual class Person
    {
        public virtual string Name { get; set; }
        public virtual string PhoneNumber { get; set; }
        public static readonly Person Unset = new Person() {
            Name = "Unset Name",
            PhoneNumber = "Unset Phone"
        };
    }
