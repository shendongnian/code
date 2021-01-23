    class SomeClass
    {
        delegate void OperationDelegate(string value);
        IDictionary<string, OperationDelegate> Operations = new Dictionary<string, OperationDelegate>();
        
        public SomeClass()
        {
            Operations.Add("objPlayer.name", SetName);
            Operations.Add("objConfig.someSetting", SetSetting); 
        }
        
        public void HandleNewValue(string command, string value)
        {
            try
            {
                if (Operations.ContainsKey(command))
                    Operations[command](value);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    
        private void SetName(string value)
        {
            // Some logic there
        }
    
        private void SetSetting(string value)
        {
            // Some logic there
        }
    }
