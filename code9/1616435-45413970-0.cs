    public class Subscription
    {
        public string id { get; set; }
        public string offerid { get; set; }
        public string offername { get; set; }
        public string friendlyname { get; set; }
        public string quantity { get; set; }
        public string parentsubscriptionid { get; set; }
        public string creationdate { get; set; }
        public string effectivestartdate { get; set; }
        public string commitmentenddate { get; set; }
        public string status { get; set; }
        public string autorenewenabled { get; set; }
        public string billingtype { get; set; }
        public string partnerbillingcycle { get; set; }
        public string partnerid { get; set; }
        public string orderid { get; set; }
        public string offerlink { get; set; }
        public string parentsubscriptionlink { get; set; }
    }
    
    public class Customer
    {
        public string customerid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string companyname { get; set; }
        public string email { get; set; }
        public string language { get; set; }
        public string culture { get; set; }
        public string addressline1 { get; set; }
        public string addressline2 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string phonenumber { get; set; }
        public string postalcode { get; set; }
        public string region { get; set; }
        public string state { get; set; }
        public string domain { get; set; }
        public string partnerid { get; set; }
        public List<Subscription> subscriptions { get; set; }
    }
    
    public class RootObject
    {
        public List<Customer> customers { get; set; }
    }
