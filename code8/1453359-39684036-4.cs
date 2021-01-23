    public delegate void OnCustomerIDChanging(object sender,CancelEventArgs e);
    public delegate void OnCustomerIDChanged(object sender,object value);
    public class Controller
    {
        private static string _customerID;
        public event OnCustomerIDChanging CustoerIDChanging;
        public event OnCustomerIDChanged CustoerIDChanged;
        public static string customerID
        {
            get { return _customerID; }
            set
            {
               // make sure that the value has a `value` and different from `_customerID`
               if(!string.IsNullOrEmpty(value) && _customerID!=value)
               {
                   if(CustomerIDChanging!=null)
                   {
                        var state = new CancelEventArgs();
                        // raise the event before changing and your code might reject the changes maybe due to violation of validation rule or something else
                        CustomerIDChanging(this,state);
                        // check if the code was not cancelled by the event from the from A
                        if(!state.Cancel)
                        {
                             // change the value and raise the event Changed
                             _customerID = value;
                             if(CustomerIDChanged!=null)
                                 CustomerIDChanged(this,value);
                        }
                   }
               }
            }
        }
    }
