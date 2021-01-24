    class A
    {
        private B _prop1;
        public B prop1
        {
            get => _prop1;
            set => SetProp(value, ref _prop1);
        }
    
        private B _prop2;
        public B prop2
        {
            get => _prop2;
            set => SetProp(value, ref _prop2);
        }
    
        private void SetProp(B value, ref B field, [CallerMemberName] string propName = null)
        {
            if(field != null) field.Association = null;
            field = value;
            if (field != null) field.Association = propName;
        }
            
    }
    
    class B
    {
        public string Association { get; set; }
    }
