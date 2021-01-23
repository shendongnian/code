    public class PaymentValidation
    {
        public bool IsValid { get; set;}
        public YourType SomeAdditionalInformation { get; set;}
    }
    public PaymentValidation EmployeeCanReiceivePayment(int employeeId)
    {
        int workingHours = this.GetEmployeeWorkingHours(employeeId);
        
        var validationResult = new PaymentValidation();
        validationResult.IsValid = true;
        if(workingHours < N)
        {
            validationResult.IsValid = false;
        }
        return validationResult;
    }
