        class HumanCredentials
        {
            public string Login { get; set; }
            public string AccessToken { get; set; }
        }
        
        class Human
        {
            public HumanName Name { get; set; }
            public HumanCredentials Credentials { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        }
