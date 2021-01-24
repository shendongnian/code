    public class Service1 : IService1
    {
        
        public AbstractResult GetAbstractData(int id)
        {
            if (id == 1)
                return new ConcreteResult1() { ID = 1,  Name = "red" };
            else
                return new ConcreteResult2() { ID = 2,  Number = 123 };
        }
    }
