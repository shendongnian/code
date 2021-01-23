    public void TryIt()
    {
        var z = new Counter();
        z.DetailsButtonClicked += Z_DetailsButtonClicked;
        z.OnDetailsButtonClicked("Greetings Earthlings");
    }
    private void Z_DetailsButtonClicked(object sender, CustomEventArgs e)
    {
        Debug.Print(e.Message);
    }
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message) { this.Message = message; }
        public string Message { get; set; }
    }
    class Counter
    {
        public event EventHandler<CustomEventArgs> DetailsButtonClicked;
        public virtual void OnDetailsButtonClicked(string message)
        {
            if (DetailsButtonClicked != null)
            {
                DetailsButtonClicked(this, new CustomEventArgs(message));
            }
        }
        // provide remaining implementation for the class
    }
