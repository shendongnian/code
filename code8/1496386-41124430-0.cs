    public class ApplianceViewModel : IAppliance
    {
        private List<IHardware> HardwareItems {get; set;}
        public ApplianceViewModel(IHardware hardware1, Hardware hardware2)
        {
            HardwareItems = new List<IHardware>();
            var hardware1 = hardware1;
            var hardware2 = hardware2;
            HardwareItems.Add(hardware1);
            HardwareItems.Add(hardware2);           
        }
    }
