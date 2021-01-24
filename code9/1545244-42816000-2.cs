    public class MyClass
    {
        public int Id { get; set; }
        public string Token { get; set; }
        //Consider this property as WelcomeSent property from your code.
        public DateTime? ExpiryDate { get; set; }
        //Use this property only to display the data in UI.
        public DateTime FormattedExpiryDate
        {
            get
            {
                return ExpiryDate != null && ExpiryDate.ToString().Length > 0
                                            ? DateTime.Parse(ExpiryDate.ToString())
                                             : new DateTime();
            }
        }
    } 
