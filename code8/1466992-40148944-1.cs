        [HttpGet]
        public IEnumerable<Employee> Get([FromQuery] string name)
        {
    	   if (!String.IsNullOrEmpty(name))
           {
		       //Return null for brevity, but you should consider
		       //returning a message saying no users were found matching the criteria.
               return null;
           }
    	   return _db.Employees.Where(x => x.Name.Contains(name)).ToList();
        }
