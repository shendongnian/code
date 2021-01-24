    public class PaymentManifestController : IPaymentManifestController
    {
        // Notice I have changed PaymentInstruction to IPaymentInstruction.
        public IAction CreateNewPaymentManifest(IPaymentInstruction request)
        {
            throw new NotImplementedException();
        }
    }
