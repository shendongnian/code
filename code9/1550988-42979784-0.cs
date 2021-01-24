    public class Project
      {        
        public int ID { get; set; }         
        public string ManagerName { get; set; }
    
        public virtual ICollection<Work> Hours { get; set; }
                            
        public Project(int id, string managerName, List<Work> work)
        {
          ID = id;
          ManagerName = managerName;
          Hours = work;
        }
      }
      
      public class Work
      {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    
        public Work(int workId, string workName, DateTime start, DateTime end)
        {
          WorkId = workId;
          WorkName = workName;
          Start = start;
          End = end;
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
    
          var dtToday = DateTime.Now.Date;
    
          var projectsAndWork = new List<Project>
          {
            new Project(1, "A", new List<Work>{ new Work(1, "Stuff", dtToday.AddDays(-5), dtToday.AddDays(-3)), new Work(2, "Things", dtToday.AddDays(-5), dtToday.AddDays(-3)) }),
            new Project(2, "B", new List<Work>{ new Work(3, "More Stuff", dtToday.AddDays(-3), dtToday), new Work(4, "More Things", dtToday.AddDays(-3), dtToday) })
          };
    
          var hunt = dtToday.AddDays(-2);
    
          var projectForMoreStuff = projectsAndWork.Where(x => x.Hours.Any(y => y.Start <= hunt && y.End >= hunt));
                           
          Console.ReadLine();
        }
      }
