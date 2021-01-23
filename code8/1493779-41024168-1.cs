    public class Product1Validator
    {
        public Product1Validator()
        {
            TicketValidator.Validate().Policy().ApplSignedState();
        }
    }  
    public class Product2Validator
    {
        public Product2Validator()
        {
            TicketValidator.Validate().Policy().ApplSignedState();
        }
    }  
    public class Product3Validator
    {
        public Product3Validator()
        {
            TicketValidator.Validate().Policy().ApplSignedState().DistributionChannel();
        }
    }  
