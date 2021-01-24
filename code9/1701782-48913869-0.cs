    public class Student
    {
        //Any length of the value is accepted for hobbies
        public List<TextPair> Hobbies{ get; set; }
    
        [ValuesLength(MaximumLength = 2, ErrorMessage = "Language code length must be 2 characters max")]
        public List<TextPair> Languages { get; set; }
    
        [ValuesLength(MaximumLength = 128, ErrorMessage = "The major should be within 128 characters length")]
        public List<TextPair> Majors{ get; set; }
    
    }
