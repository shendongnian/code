    public class MyClass {
        // DO NOT EVER DO THIS
        // classes should not contain public classes this is merely the smallest possible example
        public class StudentPoints {
            public string StudentId { get; set; }
            public double PointsValue { get; set; }
        }
    
        private IEnumerable<StudentPoints> StudentPointsList = new List<StudentPoints>();
    
        public void AddPerson(StudentPoints studentPoints) {
            this.StudentPointsList.Add(studentPoints);
        }
    }
