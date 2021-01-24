    using System;
    using WebApplication1.Entities.Contracts;
    
    namespace WebApplication1.Entities
    {
        public class BusinessManager : IBusinessManager
        {
            //Method signature in IEntityManager
            public string IAMCommon()  //Heritage in IBusinessManager (IBusinessManager : IEntityManager)
            {
                //Implement your code here.
                throw new NotImplementedException();
            }
    
            //Method signature in IBusinessManager
            public void MyBusiness() 
            {
                //Implement your code here.
                throw new NotImplementedException();
            }
        }
    }
