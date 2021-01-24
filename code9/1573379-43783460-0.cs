        private const string c_continueTerm = "Continue";
        private const string c_quitTerm = "Quit";
    
        public QuitFormField(
            string prompt,
            string nextField,
            ActiveDelegate<T> condition,
            IEnumerable<string> dependencies) : base(name: Guid.NewGuid().ToString(), role: FieldRole.Confirm)
        {
            SetPrompt(new PromptAttribute(prompt));
            SetDefine((state, field) =>
            {
                field.AddDescription(value: c_continueTerm, description: c_continueTerm).AddTerms(value: c_continueTerm, terms: c_continueTerm);
                field.AddDescription(value: c_quitTerm, description: c_quitTerm).AddTerms(value: c_quitTerm, terms: c_quitTerm);
                return Task.FromResult(true);
            });
    
            SetType(null);
            SetDependencies(dependencies?.ToArray());
            SetActive(condition);
            SetNext((value, state) => (string)value == c_continueTerm ? new NextStep(new []{nextField}) : new NextStep(StepDirection.Quit));
        }
    
        public override object GetValue(T state)
        {
            return null;
        }
    
        public override IEnumerable<string> Dependencies => _dependencies;
    
        public override bool Active(T state)
        {
            return _condition(state);
        }
    
        public override NextStep Next(object value, T state)
        {
            return _next((string)value, state);
        }
    
        public override void SetValue(T state, object value)
        {}
    
        public override bool IsUnknown(T state)
        {
            return true;
        }
    
        public override void SetUnknown(T state)
        {
            throw new NotImplementedException();
        }
    
