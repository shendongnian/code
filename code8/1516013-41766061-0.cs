    [DebuggerTypeProxy(typeof(ComplexTypeProxy))]
    class ComplexType
    {
        // complex state
    }
    class ComplexTypeProxy
    {
        public string Display
        {
            get { return "Create a multi-line representation of _content's complex state here."; }
        }
        private ComplexType _content;
        public ComplexTypeProxy(ComplexType content)
        {
            _content = content;
        }
    }
