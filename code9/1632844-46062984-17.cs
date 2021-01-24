    public class Student
    {
        [StringLength(100)]
        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Please enter a Student Name")]
        public string Name { get; set; }
        [StringLength(100)]
        [DisplayName("Student Number")]
        [Required(ErrorMessage = "Please enter a Student Number")]
        public string StudentNumber { get; set; }
        // etc...
    }
