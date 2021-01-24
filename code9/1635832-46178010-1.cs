    public class ContactosService : IContactosService
    {
        private readonly IExecutionService _executionService;
        public ContactosService(IExecutionService executionService)
        {
            _executionService = executionService;
        }
        public void AddContact(Contact_mdl value)
        {
            _executionService.Execute(rep => rep.Add(value));
        }
        public void DeleteContact(int id)
        {
            _executionService.Execute(rep => rep.Delete(id));
        }
    }
    public class ExecutionService : IExecutionService
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
