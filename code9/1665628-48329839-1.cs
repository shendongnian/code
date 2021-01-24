        public class SportDto
        {
            public string Name { get; set; }
        }
        public class UserDto
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Email { get; set; }
            public String Password { get; set; }
            public List<SportDto> Sports { get; set; }
        }
