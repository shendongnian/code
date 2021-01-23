        public class Student
        {
            [NotMapped]
            public Subject Subject { get {
                return QueryAPIHere(this.SubjectId);
            } set; }
        }
