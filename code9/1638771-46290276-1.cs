    public class PersonController : ApiController  
    {
        [HttpPost]
        public Person Index(Person Person,  Building Building)
        {
            return Person;
        }
    }
