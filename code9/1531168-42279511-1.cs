    public class MyClass {
        private Dictionary<int, double> StudentPoints = new Dictionary<int, double>(); //was string, double
    
        [Obsolete] // unfixed code will call this
        public void AddPerson(string studentId, double val) {
            int studentIdInt;
            if (Int32.TryParse(studentId, out studentIdInt) {
                this.AddPerson(studentIdInt, val);
                return;
            }
            throw new ArgumentException(nameof(studentId), "string not convertable to int");
        }
    
        public void AddPerson(int studentId, double val) {
            this.StudentList.Add(studentId, val);
        }
    }
