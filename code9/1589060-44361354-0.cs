    public class ContactsController : ApiController {
        public async Task<List<Models.Contact>> Get() {
            var client = await SalesforceService.GetUserNamePasswordForceClientAsync();
            var contacts = await client.QueryAsync<Models.Contact>("SELECT id, FirstName, LastName, Email FROM Contact");
            var sfContact = contacts.Records;
    
            return sfContacts;
        }
    }
