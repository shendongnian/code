    public class FormFactory
    {
        Dictionary<string, Form> forms = new Dictionary<string, Form>();
        private static FormFactory _factory;
        public void SetForm(string name, Form form)
        {
            forms[name] = form;
        }
        public Form GetForm(string name)
        {
            if (forms.ContainsKey(name))
                return forms[name];
            return null;
        }
        private FormFactory()
        {
        }
        static FormFactory()
        {
            _factory = new FormFactory();
        }
        public static FormFactory Instance
        {
            get
            {
                return _factory;
            }
        }
    }
