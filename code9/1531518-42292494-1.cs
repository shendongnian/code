        public class Groups
        {
            public int Id { get; set; }
            public string GroupName { get; set; }
        }
        public class transMedHandler
        {
            public static List<Groups> GetGroupNames()
            {
                return new List<Groups>() 
                {
                    new Groups {Id = 1, GroupName = "cardia connections" }, 
                    new Groups { Id = 2, GroupName = "citizens group" }, 
                    new Groups { Id = 3, GroupName = "testgroup etc" }
                };
            }
            public static List<Groups> GetNames()
            {
                return new List<Groups>() 
                { 
                    new Groups { Id = 1, GroupName = "active" }, 
                    new Groups { Id = 2, GroupName = "assigned" }, 
                    new Groups { Id = 3, GroupName = "returned" }, 
                    new Groups{ Id = 4, GroupName = "deactivated" }
                };
            }
        }
