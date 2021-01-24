     [Table("Client")]
            public class Client: ApplicationUser
            {
                public string Name { get; set; }
                public string Address { get; set; }
                public string Password{ get; set; }
            }
