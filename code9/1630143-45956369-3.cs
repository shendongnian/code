    public class TestViewModel : ViewModelBase
    {
        public Func<Task<byte[]>> SignatureFromStream { get; set; }
        public byte[] Signature { get; set; }
        public ICommand MyCommand => new Command(async () =>
        {
            Signature = await SignatureFromStream();
            // Signature should be != null
        });
    }
