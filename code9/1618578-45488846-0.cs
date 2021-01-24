    interface IWorkerBase
    {
        ISettingsBase Settings { get; set; }
    }
    
    interface IWorkerExtended : IWorkerBase
    {
        IExtendedSettings Settings { get; set; }
    }
