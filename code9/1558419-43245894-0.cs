    class Student : Person
    {
        private int StudentId;
        public Student(string name, int age, int studentId)
            : base(name, age)
        {
            StudentId = studentId;
        }
    }
