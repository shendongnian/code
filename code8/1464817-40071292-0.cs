    public class MyView : View
    {
        public event EventHandler<string> MyEvent;
        public void RaiseEvent(string parameter)
        {
            MyEvent?.Invoke(this, parameter);
        }
    }
