    abstract class Car
    {
        public void Drive()
        {
            IgnitionOn();
            EngineOn();
            EngageTransmission();
        }
        protected abstract void IgnitionOn();
        protected abstract void EngineOn();      
        protected abstract void EngageTransmission();
    }
