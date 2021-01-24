    {
        public string depart
        {
            get
            {
                EmpolyeeEntities db = new EmpolyeeEntities();
                var empid = db.Empolyees.Select(e=>e.Department).SingleOrDefault();
             
                 var dpname = db.Department1.Where(x => x.Id == empid).Select(f => f.Department).SingleOrDefault();
              
                return dpname.ToString();
            }
        }
