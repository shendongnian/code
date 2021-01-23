    public class ToastService
    {
        public event Action<String> ToastMessageRecieved;
        public void ShowToast(string message)
        {
            ToastMessageRecieved(message);
        }
    }
