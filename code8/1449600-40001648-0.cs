    public class IMachine
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
    public interface IEquipmentData { IMachine Machine { get; set; } }
    public class MachineDataViewModel : IEquipmentData
    {
        public IMachine Machine { get; set; }
        public MachineDataViewModel(IMachine machine) { Machine = machine; }
    }
