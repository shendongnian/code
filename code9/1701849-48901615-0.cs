             List<Employee> emplist = new List<Employee>();
                emplist.Add(new Employee() {EmpName="A",JobTitleId=0,GenderId=0 });
                emplist.Add(new Employee() { EmpName = "B", JobTitleId = 1, GenderId = 0 });
                emplist.Add(new Employee() { EmpName = "C", JobTitleId = 0, GenderId = 1 });
                emplist.Add(new Employee() { EmpName = "D", JobTitleId = 1, GenderId = 1 });
                int jobid = 1;
                int genderid = 1;
                var result = from em in emplist where ((em.JobTitleId > 0 && em.JobTitleId == jobid) ||  (em.GenderId > 0 && em.GenderId == genderid)) select em;           
                foreach (Employee emp in result)
                    Console.WriteLine(emp.EmpName);
                Console.ReadKey();
