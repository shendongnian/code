    public interface IListen
    {
        void SendMessage(string msg);
        void SendDictonary(IDictionary<object, object> dic);
    }
    public class MyDllClass
    {
        public IListen Listener
        {
            get;
            set;
        }
        public void SomeMouseInputAppears()
        {
            if(Listener != null) Listener.SendMessage("sample");
        }
        public void SomeKeyboardInputAppears()
        {
            if (Listener != null) Listener.SendDictonary(new Dictionary<object,object>());
        }
    }
