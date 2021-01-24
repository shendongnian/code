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
        public void Execute(Action<Contact_rep> command)
        {
            using (var myCon = new AdoNetContext(new AppConfigConnectionFactory(EmpresaId)))
            {
                using (var rep = new Contact_rep(myCon))
                {
                    command(rep);
                }
            }
        }
    }
