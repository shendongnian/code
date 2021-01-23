    using System;
    namespace Event2_2
    {
        class Product
        {
            public void OnSendMail()
            {
                Productfinished?.Invoke(this, new EventArgs());
            }
            public event EventHandler<EventArgs> Productfinished;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Product pd = new Product();
                pd.Productfinished += SendMail;
                pd.OnSendMail();
            }
            public static void SendMail(object sender, EventArgs eventArgs)
            {
                Console.WriteLine("Mail sent to Vendor");
            }
        }
    }
