    public class Controller
    {
        //You can pass the form throught the constructor,
        //create it in constructor, ...
        private FormA frmA;
      
        private string _customerID;
        public string customerID
        {
            get { return _customerID; }
            set
            {
                _customerID = value;
                if (_customerID != "")
                {
                    frmA.ChangeMe();
                }
            }
        }
    }
