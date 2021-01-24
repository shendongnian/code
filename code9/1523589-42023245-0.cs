    public static List<Student> items = new List<Student>();
         
    
            [HttpGet]
            public IEnumerable<Student> GetAllStudents()
            {
                if (items.Count() == 0)
                {
                    items.Add(new Student { ID = 1, Name = "Ashish", City = "New Delhi", Course = "B.Tech" });
                    items.Add(new Student { ID = 2, Name = "Nimit", City = "Noida", Course = "MCA" });
                    items.Add(new Student { ID = 3, Name = "Prawah", City = "Dehradun", Course = "B.Tech" });
                    items.Add(new Student { ID = 4, Name = "Sumit", City = "Nainital", Course = "MCA" });
                }
                
                return items;
            }
