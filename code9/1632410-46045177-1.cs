    class Program
    {
        static void Main(string[] args)
        {
            var recs = new List<Recursos> {
    new Recursos { Name = "Alex", Email = "A", RecursoID= 1 },
    new Recursos { Name = "Juan", Email = "B", RecursoID= 2 },
    new Recursos { Name = "Peter", Email = "C", RecursoID= 3 },
    new Recursos { Name = "Julios", Email = "D", RecursoID= 4 },
    new Recursos { Name = "Dennis", Email = "E", RecursoID= 5 },
    new Recursos { Name = "Jhon", Email = "F", RecursoID= 6 },
    };
            var citas = new List<Citas> {
    new Citas { RecursoID= 1, CitaID = 1 },
    new Citas { RecursoID= 1, CitaID = 2 },
    new Citas { RecursoID= 2, CitaID = 3 },
    };
            var citasbyRecurso =
                from r in recs
                join c in citas on r.RecursoID equals c.RecursoID into cleft
                select new
                {
                    RecursoID = r.RecursoID,
                    Name = r.Name,
                    Email = r.Email,
                    Count = cleft.Where(x=>x.RecursoID == r.RecursoID).Count(),
                };
            foreach (var item in citasbyRecurso)
            {
                Console.WriteLine(string.Format("{0} {1} {2} {3}", item.RecursoID,item.Name,item.Email, item.Count));
            }
            Console.ReadLine();
        }
    }
    class Recursos
    {
        public int RecursoID;
        public string Name;
        public string Email;
    }
    class Citas
    {
        public int RecursoID;
        public int CitaID;
    }
