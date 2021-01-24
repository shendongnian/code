    namespace App.Services.Interfaces
    {
        [ServiceContract]
        public interface IService1
        {   
            [FaultContract(typeOf(AppException))]
            [OperationContract]
            void TestFunction();
        }
    }
    using System.ServiceModel;
    public class Service1 : IService1
        {
            public Service1 () 
            { }
    
            public void TestFunction() 
            {
                try
                {
                 service.TestFunction();
                }
                catch(Exception ex)
                 {
                   AppException app=new AppException();
                   app.strMessage =ex.Message;
                   throw new FaultExcpetion<AppException>(app);
                 }
            }
        }
