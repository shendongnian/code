    public class AddPersonController : ApiController {
        [HttpPost]
        public IHttpActionResult InsertRecord([FromBody]Models.Person model) {
    
            if (ModelState.IsValid) {
                var person = new Person {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = Convert.ToDateTime(model.DateOfBirth)
                };
    
                _dbContext.People.Add(person);
                _dbContext.SaveChanges();
    
                var id = person.P_id;
    
                return Ok(id);
            } else {
                return BadRequest();
            }
        }
    }
