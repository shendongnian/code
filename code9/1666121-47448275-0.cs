     public class HomeController : Controller
        {
          public async Task<ActionResult> GetPersonRecord(string id)
            {
                PersonController person =new PersonController();
                var Value =person.PersonDetails()
                Value = JsonConvert.DeserializeObject<Person>(results);
                string json = JsonConvert.SerializeObject(person, Formatting.Indented);
                return Content(json, "application/json");
            }
        }
   
     public class PersonController : Controller
     { 
         [HTTPPOST]
         public void  PersonDetails ( int PersonID)
         { 
           return XXXX;
         } 
     }
