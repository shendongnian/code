    public class CustomerContactCommunicationValidator : AbstractValidator<CustomerCommunication>
    {
       public CustomerContactCommunicationValidator()
       {
           RuleForEach(x => x.PhoneNumbers).Length(0, 35);
           RuleForEach(x => x.FaxNumbers).Length(0, 35);
       }
    }
