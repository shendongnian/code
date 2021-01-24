         [Serializable]
    public class BaseEntity 
    {
        Dictionary<string, object> _dic;
        public BaseEntity()
        {
            _dic = new Dictionary<string, object>();
        }
        public object this[string propertyName]
        {
            get
            {
                return _dic[propertyName];
            }
            set
            {
                _dic[propertyName] = value;
            }
        }      
    }
    public class tblCustomer : BaseEntity
    {
        public int CustomerID
        {
            get
            {
                return (int)this["CustomerID"];
            }
            set
            {
                this["CustomerID"] = value;
            }
        }
        public string Status
        {
            get
            {
                return (string)this["Status"];
            }
            set
            {
                this["Status"] = value;
            }
        }
    }
