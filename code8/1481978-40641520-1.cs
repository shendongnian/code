    class DieselCarWithManualGearbox : Car
    {
        protected override void IgnitionOn()
        {
            IgnitionControlModule.IgnitionState = IgnitionState.On;
        }
        protected override void EngineOn()
        {
            DieselEngine.StartFuelPump();
            DieselEngine.Run();
        }
        protected override void EngageTransmission()
        {
            ManualGearbox.Gear = 1;
        }
    }
