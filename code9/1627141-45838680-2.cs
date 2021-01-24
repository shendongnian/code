    //Presentation
    using BusinessLayer;
    using BusinessLayer.Models;
    namespace ContactService.Controllers
    {
        public class ContactController : ApiController
        {
            public void Post([FromBody] Contact contact)
            {
                Business bu = new Business();
                var client = bu.getcontact(contact);
                //Do something with the client, if you want.
                Fname = client.Fname;
                lname = client.Lname;
                age = client.Age.ToString();
    
            }
        }
    }
