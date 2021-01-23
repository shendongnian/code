    public class CustomBinding : Binding
    {
        public CustomBinding(string path)
            :base(path)
        {
            this.NotifyOnValidationError = true;
        }
    }
