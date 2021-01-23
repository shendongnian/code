    public class PrimitiveAddresses
    {
        private string _city;
        public string City
        {
            get
            {
                if(_city != null) {return _city;}
                else {throw new CommandInvalidException("No valid city provided");}                 
            }
            set
            {
                _city = value;
            }
        }
       
    }
    public class CommandInvalidException: Exception
    {
        public CommandInvalidException(string message)
        : base(message)
        {
        }
    }
