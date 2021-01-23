    class Student
    {
        public Student()
        {
        }
    
        public int Student_ID { get; set; }
        public string StudentName { get; set; }
            
        [Index]
        public int RegistrationNumber { get; set; }
    }
