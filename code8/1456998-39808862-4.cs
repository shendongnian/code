    public class NotEnoughWorkingHoursPayment : IPayment
    {
        public void Pay()
        {
            //Do nothing or log failed payment or inform user about it
        }
    }
    public class SuccesfullPayment : IPayment
    {
        public void Pay()
        {
            //Execute payment
        }
    }
 
    public class PaymentService
    {
        public IPayment ValidatePayment()
        {
            const int MIN_WORKING_HOURS = 40;
            int workingHours = this.GetEmployeeWorkingHours(employeeId);
            if(workingHourse < MIN_WORKING_HOURS)
            {
                return New NotEnoughWorkingHoursPayment();
            }
            return new SuccesfullPayment();
        }
    }
