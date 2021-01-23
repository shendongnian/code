    // By making this inherit from EventArgs, we can use the built-in EventHandler<T> delegate for the event itself.
    public class ClientServiceAttachedEventArgs : EventArgs
    {
        public AttachedStatus AttachStatus { get; set; }
        public ServiceAttachStatus ServiceAttachStatus  { get; set; }
        public string Message { get; set; }
        // You can put in as many properties as you want to carry the information back from the server.
    }
