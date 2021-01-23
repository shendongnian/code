    public interface IFormFactory
    {
        Owned<Form> CreateForm(string formName);
    }
    public class FormFactory : IFormFactory
    {
        private readonly IContainer _container;
        public FormFactory(IContainer container)
        {
            _container = container;
        }
        public Owned<Form> CreateForm(string formName)
        {
            return _container.ResolveNamed<Owned<Form>>(formName);
        }
    }
