    [AddInContract]
    public interface IPluginContract : IContract
    {
        INativeHandleContract GetControl();
        double GetHeight();
        void SetHostCallback(IHostCallbackContract callback);
    }
