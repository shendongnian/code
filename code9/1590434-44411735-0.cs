    public class Base {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Base(string name, string surname) {
            Name = name;
            Surname = surname;
        }
    }
    public class Student : Base, ICloneable {  // ICloneable
        public int StudentID { get; set; }
        public Student(string name, string surname, int studentID) : base(name, surname) {
            //Name = name;
            //Surname = surname;
            StudentID = studentID;
        }
        public override string ToString() {
            return string.Format("Name is {0}, surname is {1}, ID is {2}", Name, Surname, StudentID);
        }
        public object Clone() {
            return MemberwiseClone();
        }
    }
    public class Teacher : Base {  // Copy constructor
        public string TeachingSubject { get; set; }
        public Teacher(string name, string surname, string teachingSubject) : base(name, surname) {
            //Name = name;
            //Surname = surname;
            TeachingSubject = teachingSubject;
        }
        public override string ToString() {
            return string.Format("Name is {0}, surname is {1}, TeachingSubject is {2}", Name, Surname, TeachingSubject);
        }
        public Teacher(Teacher obj) : base(obj.Name, obj.Surname) {
            TeachingSubject = obj.TeachingSubject;
        }
    }
