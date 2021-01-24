    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    namespace WebAPICall.Controllers
    {
        public class PeopleController : ApiController
        {
            List<Person> people = new List<Person> { new Person { Id = 1, Name = "John" }, new Person { Id = 2, Name = "Mary" } };
        
            // GET api/People/1
            public IHttpActionResult Get(int id)
            {
                Person person = people.FirstOrDefault(p => p.Id == id);
                if (person == null)
                {
                    return NotFound();
                }
                return Ok(person);
            }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
