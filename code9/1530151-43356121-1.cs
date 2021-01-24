    public enum RequestType : int
    {
        Enrol = 1,
        ReEnrol,
        UpdateEnrolment
    }
    public interface IRequest
    {
        void CallService();
    }
    public class EnrolmentRequest : IRequest
    {
        public void CallService()
        {
            // Code for EnrolmentRequest
        }
    }
    public class ReEnrolmentRequest : IRequest
    {
        public void CallService()
        {
            // Code for ReEnrolmentRequest
        }
    }
    public class UpdateEnrolmentRequest : IRequest
    {
        public void CallService()
        {
            // Code for UpdateEnrolmentRequest
        }
    }
    // Factory Class
    public class FactoryChoice
    {
        private IDictionary<RequestType, IRequest> _choices;
        public FactoryChoice()
        {
            _choices = new Dictionary<RequestType, IRequest>
                {
                    {RequestType.Enrol, new EnrolmentRequest() },
                    {RequestType.ReEnrol, new ReEnrolmentRequest()},
                    {RequestType.UpdateEnrolment, new UpdateEnrolmentRequest()}
                };
        }
        static public IRequest getChoiceObj(RequestType choice)
        {
            var factory = new FactoryChoice();
            return factory._choices[choice];
        }
    }
