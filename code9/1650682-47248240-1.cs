    public class ExtendedEnquiryFactory : IEnquiryFactory
    {
        public Enquiry Create(string firstName,string surname)
        {
            return new ExtendedEnquiry(firstName,surname);
        }
    }
    
    public class ExtendedEnquiry : Enquiry
    {
    }
