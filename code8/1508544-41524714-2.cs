    public class User
    {   // critical
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
             
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get { return DateTime.Now.Date.Year - DateOfBirth.Date.Year; }
        }
        
        public string Gender { get; set; }
        public int CurrentWeight { get; set; }
        public int Targetweight { get; set; }
        
        private static string dbConnStr = "server=127.0.0.1;database=...";
        public User()
        { }
     ...
