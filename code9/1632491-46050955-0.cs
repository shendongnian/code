    public List<EMPLOYEE> Get([FromUri] EMPLOYEE query)
            {
    
                List<EMPLOYEE> emps = new List<EMPLOYEE>();
                var db = AuthHandler.Ent;
                var queryable = (ObjectQuery<EMPLOYEE>)db.EMPLOYEES.AsExpandable();
    
                string condition = "CONTAINS(@column, @search)";
    
                foreach (var prop in query.GetType().GetProperties())
                {
                    var value = prop.GetValue(query, null);
                    if (value != null)
                    {
                        queryable = queryable.Where(string.Format(condition, prop.Name, value));
                    }
                }
                emps = queryable.ToList();
    
                return emps;
    
            }
