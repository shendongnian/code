    [DataContract(Namespace = "http://noatariff.com")]
    public class Customer
    {
        public Customer()
        {
            DateTime now = DateTime.Now;
            string datePart = now.ToString("yyyy-MM-dd");
            string timePart = now.ToString("HH:mm:ss.fffzzz");
            this.TimeReceived = String.Format("{0}T{1}", datePart, timePart);
        }
    
        [DataMember]
        public string TimeReceived { get; set; }    
    }
