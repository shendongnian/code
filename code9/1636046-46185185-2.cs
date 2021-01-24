    public class MyDateValidation: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // check your business date property  
            DateTime myDatetime;
            bool isParsed = DateTime.TryParse((string)value, out myDatetime);
            if(!isParsed)
                return false;
            return true;
        }
    }
    
    [MyDateValidation(ErrorMessage="Your message")]
    public Datetime myDate { get; set; }
