    class MyViewModel
    {
        Dictionary<string,object> _dict=new Dictionary<string,object>();
        
        //Get helper
        private T getter<T>([CallerMemberName]string name=null)
        {
            return _dict.TryGetValue(name,out object value)
                ? (T)Convert.ChangeType(value,typeof(T))
                : default(T);            
        }
        
        private void setter(object value,[CallerMemberName]string name=null)
        {
            _dict[name]=value;
        }
        
        public DateTime Date { 
            get => getter<DateTime>();            
            set => setter(value); 
        }               
        public string Name { 
            get => getter<string>();            
            set => setter(value); 
        }
        public bool IsEnabled { 
            get => getter<bool>();            
            set => setter(value); 
        }
        
        public MyViewModel(IEnumerable<FormField> fields)
        {
            _dict=fields.ToDictionary(
                             field=>field.FieldName,
                             field=>(object)field.FieldValue);
        }
        
    }
    ....
    var formData = new [] {
        new FormField { FieldName = "Date", FieldValue = "2017-09-14" },
        new FormField { FieldName = "Name", FieldValue = "Job blogs" },
        new FormField { FieldName = "IsEnabled", FieldValue = "true" }
    };
    
    var myViewModel = new MyViewModel(formData);
