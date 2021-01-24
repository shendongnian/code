    class BaseBusinessLogic
    {
        public void commonMethod1() 
        {
        }
        public void commonMethod2() 
        {
        }
        public Object GetXData()
        { 
                var service = new DBconnector();
                ...//setting
                return service.GetExcetue();
        }
    }
    Class BusinessLogicM1 : BaseBusinessLogic
    {
          public void M1LogicMethod()
          {
              ..........
          }
    }
