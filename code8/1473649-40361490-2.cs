     using System.Linq.Dynamic;
     public virtual IEnumerable<Person> Get(string condition)
        {
            using (var ctx = MyContext())
            {
                return = ctx.DbContext.People.Where(condition).ToList();
            }
        }
