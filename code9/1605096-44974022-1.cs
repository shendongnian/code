    public class Author
    {
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public override string ToString()
        {
            return $"Author Number: {Number}\nAuthor First Name: {FirstName}\nAuthor Last Name: {LastName}";
        }
    }
