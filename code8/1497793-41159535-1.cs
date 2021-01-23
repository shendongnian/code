    class Student
    {
        public string Name { get; set; }
        public Student(string Name) //constructor here
        {
            this.Name = Name;
        }
        public override string ToString() //overload of ToString
        {
            return Name.ToString();
        }
    }
