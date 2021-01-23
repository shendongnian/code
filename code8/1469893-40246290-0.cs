    namespace MyApplication
    {
        public interface IMyCar
        {
            void DoSomething();
        }
    }
    
    namespace Adaptors
    {
        public class CarAdaptor : MyApplication.IMyCar
        {
            private readonly ThirdParty.ICar car;
            
            public CarAdaptor(ThirdParty.ICar car) {this.car = car;}
    
            public void DoSomething() { car.Do3rdPartyThing();}
        }
    }
