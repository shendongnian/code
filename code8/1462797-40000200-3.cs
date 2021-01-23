    public class Translation : BindableBase, IDataErrorInfo
    {
        public string Value { get; set; }
        public string this[string propertyName]
        {
            get
            {
                return GetErrorForPropery(propertyName);
            }
        }
        public string Error { get; }
        private string GetErrorForPropery(string propertyName)
        {
            switch (propertyName)
            {
                case "Value":
                    if (string.IsNullOrEmpty(Value))
                    {
                        return "Please enter value";
                    }
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
