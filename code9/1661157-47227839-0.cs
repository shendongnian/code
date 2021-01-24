    public interface IExternalDeviceInteractor
    {
        string GetAStringFromTheDevice();
    }
    public class ExternalDeviceInteractor : IExternalDeviceInteractor
    {
        public string GetAStringFromTheDevice()
        {
            //interact with device here
        }
    }
