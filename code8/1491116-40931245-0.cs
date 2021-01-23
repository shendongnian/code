    public class MyControl: UserControl
    {
        
        private void MyMethodCalledFromAnOtherThread()
        {
            this.Dispatcher.Invoke(new Action(
            {
                // Change the collection...
                myCol.Add("Hi there");
            });
        }
