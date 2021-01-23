    public abstract class BaseClass
    {
        //...
        private readonly Dictionary<string, object> _settings = new Dictionary<string, object>();
    
        protected BaseClass() { }
    
        public object GetSetting(string name)
        {
            if ("Text".Equals(name))
            {
                return this.GetTextValue();
            }
            return this._settings[name];
        }
    
        // this forces every derived class to have a "Text" value
        // the value could be hard coded in derived classes of held as a variable
        protected abstract GetTextValue();
    
        protected void AddSetting(string name, object value)
        {
            this._settings[name] = value;
        }
    
    
        //...
    }
