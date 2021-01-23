    interface ICallTheService
    {
        void CallTheService();
    }
    
    class ServiceCaller : ICallTheService
    {
        void CallTheService()
        {
            // Call the service...
        }
    }
    
    var serviceCaller = A.Fake<ICallTheService>();
    
    A.CallTo(() => serviceCaller.CallTheService()).MustHaveHappened();
