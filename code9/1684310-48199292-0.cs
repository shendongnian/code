    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LinkedContext;
    namespace TryAgain
    {
        class Program
        {
            static void Main(string[] args)
            {
                LinkedDataContext db = new LinkedDataContext();
                var example = from x in db.employees
                              orderby x.employee_id
                              select x;
                foreach (var whatever in example)
                {        
                    Console.WriteLine(whatever.name);
                }
