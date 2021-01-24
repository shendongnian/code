    public class Worker : IWorkerExtended
    {
        public IExtendedSettings Settings { get; set; }
        ISettingsBase IWorkerBase.Settings { get; set; }
    }
