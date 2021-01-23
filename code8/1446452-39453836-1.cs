        public partial class Enrollment
        {
            public int EnrollmentID { get; set; }
            public Nullable<decimal> Grade { get; set; }
            public int CourseID { get; set; }
            public int StudentID { get; set; }
    
            public virtual Course Course { get; set; }
            public virtual Student Student { get; set; }
       }
