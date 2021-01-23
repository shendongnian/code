    public class FakeContactRepository : IContactRepository {
        private ICollection<Contact> data;
        public FakeContactRepository(ICollection<Contact> data) {                
            this.data = data;
        }
        public void Add(Contact contact) {
            data.Add(contact);
        }
        public IEnumerable<Contact> GetContacts(string _userId) {
            return data;
        }
    }
