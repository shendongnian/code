       [HttpPost]
        public IEnumerable<Employee> Post([FromBody] string name)
        {
            IEnumerable<Employee> query = Enumerable.Empty<Employee>();
            if (!String.IsNullOrEmpty(name))
            {
                query = from e in _db.Employees
                where e.Name.Contains(name)
                select e;
            }
            return query.ToList();
        }
