        public object Read(string variable)
        {
            ...
            try
            {
                ...
            }
            catch 
            {
                lastErrorCode = ErrorCode.WrongVarFormat;
                lastErrorString = "Die Variable '" + variable + "' konnte nicht entschlüsselt werden!";
                return lastErrorCode;
            }
        }
