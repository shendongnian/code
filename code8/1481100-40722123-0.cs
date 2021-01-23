    public class User
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
        }
        private static void jsonDeserialize()
        {
            var json = "{\"Name\":\"ABC\",\"Address\":\"Street1,Street2\",\"City\":\"Pune\"}";
        
            User user = JsonConvert.DeserializeObject<User>(json);
            Console.WriteLine("Name = "+ user.Name);
            Console.WriteLine("Address = " + user.Address);
        }
