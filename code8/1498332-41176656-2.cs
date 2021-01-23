    public class HybridEngine : Engine
    {
        private IBattery _battery;
        private bool HasElectricCharge()
        {
            return _battery.HasCharge();
        }
        public void PressAccelerator()
        {
            if(HasElectricCharge())
                this.PumpElectronsInto(_electricMotor);
            else
                this.InjectFuelInto(_engine);
        }
    }
