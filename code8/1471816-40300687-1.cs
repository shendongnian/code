    using System;
    namespace Event2_2
    {
        public sealed class SendMailEventArgs : EventArgs
        {
            public SendMailEventArgs(string recipient)
            {
                Recipient = recipient;
            }
            public string Recipient { get; }
        }
        class Product
        {
            public void OnSendMail(string recipient)
            {
                Productfinished?.Invoke(this, new SendMailEventArgs(recipient));
            }
            public event EventHandler<SendMailEventArgs> Productfinished;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Product pd = new Product();
                pd.Productfinished += SendMail;
                pd.OnSendMail("Test Recipient");
            }
            public static void SendMail(object sender, SendMailEventArgs eventArgs)
            {
                Console.WriteLine("Mail sent to recipient: " + eventArgs.Recipient);
            }
        }
    }
