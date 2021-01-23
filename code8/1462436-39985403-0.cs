        public virtual String Message {
               get {  
                if (_message == null) {
                    if (_className==null) {
                        _className = GetClassName();
                    }
                    return Environment.GetResourceString("Exception_WasThrown", _className);
 
                } else {
                    return _message;
                }
            }
        }
