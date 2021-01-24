    using System;
    using WebApplication1.Entities.Contracts;
    
    namespace WebApplication1.Entities
    {
        public class PayerManager : IPayerManager
        {
            //Method signature in IEntityManager
            public string IAMCommon() //Heritage in IPayerManager (IPayerManager : IEntityManager)
            {
                //Implement your code here.
                throw new NotImplementedException();
            }
    
            //Method signature in IPayerManager
            public void MyPayer()
            {
                //Implement your code here.
                throw new NotImplementedException();
            }
        }
    }
