    public class ContactosService : IContactosService
    {
        private readonly IContactRepository repository;
        public ContactosService(IContactRepository repository)
        {
            this.repository = repository;
        }
        public void AddContact(Contact_mdl value)
        {
            repository.Execute(rep => rep.Add(value));
        }
        public void DeleteContact(int id)
        {
            repository.Execute(rep => rep.Delete(id));
        }
    }
    public class ContactRepository : IContactRepository
    {
        private readonly string _empresaId;
        pubic ContactRepository(string empresaId)
        {
             _empresaId = empresaId;
        }
        public void Execute(Action<Contact_rep> command)
        {
            using (var myCon = new AdoNetContext(new AppConfigConnectionFactory(_empresaId)))
            {
                using (var rep = new Contact_rep(myCon))
                {
                    command(rep);
                }
            }
        }
    }
