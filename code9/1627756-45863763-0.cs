    public class BaseEventArgs : EventArgs {
        public IBase Data;
    }
    public event EventHandler<BaseEventArgs> Update;
    void SendData(IBase data)
    {
        Update?.Invoke(this, new BaseEventArgs { Data = data } );
    }
