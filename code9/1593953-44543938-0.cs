    public class WorkHour //: DomainEntity<int>
        {
            //public virtual Day day { get; set; }
    
            [Key]
            public int id;
    
            [Required]
            public int dayId { get; set; }
            public TimeSpan startTime { get; set; }
            public TimeSpan endTime { get; set; }
            public DateTime created { get; set; }
            public bool deleted { get; set; }
        }
    
    
        public class Test
        {
            public void Main()
            {
                var o = new WorkHour()
                {
                    created = DateTime.Now,
                    dayId = 0,
                    deleted = false,
                    endTime = new TimeSpan(0, 0, 2),
                    startTime = new TimeSpan(0, 0, 2),
                    id = 0,
                };
                Console.WriteLine( JsonConvert.SerializeObject(o));
                
            }
    
        }
