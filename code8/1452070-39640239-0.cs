    public class CreateStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    } 
    public class EditStudent : CreateStudent
    {
        public DateTime Date_of_Birth { get; set; }
    }
