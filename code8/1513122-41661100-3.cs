           public class TestContext:DbContext
            {
                public TestContext()
                    : base("name=TestConnection")
                {
                }
              public virtual  DbSet<Bus> Buses { get; set; }
                public virtual DbSet<Booking> Bookings { get; set; }
            }
        }
        public class Booking
        {    
            public int Id { get; set; }
            public Bus Bus { get; set; }  
            public int BusId { get; set; }
            public DateTime DateTime { get; set; }
            public int AvailableSeats { get; set; }   
        }
        public class Bus
        {
            public int Id { get; set; }
            public string BusNumber { get; set; }
            public int BusSeats { get; set; }
        }
