    public class ContactsController : ApiController {
        public async Task<IHttpActionResult> Get() {
            var client = await SalesforceService.GetUserNamePasswordForceClientAsync();
            var contacts = await client.QueryAsync<Models.Contact>("SELECT id, FirstName, LastName, Email FROM Contact");
            var sfContact = contacts.Records
                                    .Select(c => new {
                                        c.id,
                                        c.FirstName,
                                        c.LastName,
                                        c.Email
                                    });
    
            return Ok(sfContacts);
        }
    }
