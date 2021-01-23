    public class TestValue
    {
        private string __ccAlias = string.Empty; // backing field
       public string CcAlias
       {
            get
            {
                // return value of backing field
                return string.IsNullOrEmpty(_ccAlias) ? string.Empty : _ccAlias;
            }
            set
            {
                // set backing field to value or string.Empty if value is null
                _ccAlias = value ?? string.Empty;
            }
        }
    }
