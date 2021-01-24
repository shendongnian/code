    public class DataAccess
    {
     private string _value;
     
    public string value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value.Trim();
            }
        }
    
    }
