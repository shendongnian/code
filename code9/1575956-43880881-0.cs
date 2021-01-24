    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace efAW
    {
        class Program
        {
    
            static IEnumerable GetAllMembers(DbContext db, string dbSetName)
            {
                var pi = db.GetType().GetProperty(dbSetName);
                return (IEnumerable)pi.GetValue(db);
            }
            static void Main(string[] args)
            {
                using (var db = new aw())
                {
                    var customers = GetAllMembers(db, "Customers").OfType<Customer>().ToList();
                }
            }
        }
    }
