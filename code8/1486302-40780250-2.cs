     public class MainEntry  {     
            public int MainEntryId { get; set; }
            public string TeamAssignment { get; set; }
            public string Role { get; set; }
            public string Series { get; set; }  
            public string Stock { get; set; } 
            public string Points { get; set; }
            public IEnumerable<Team> Teamname { get; set; }//(dropwon fill)
            public IEnumerable<Team> Teamage //(dropwon fill)
            public IEnumerable<Team> TeamLocation //(dropwon fill)  }
