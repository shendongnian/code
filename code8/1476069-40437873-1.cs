    public class Billing
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
    
    public class Shipping
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string company { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }
    
    public class LineItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public int product_id { get; set; }
        public int variation_id { get; set; }
        public int quantity { get; set; }
        public string tax_class { get; set; }
        public string price { get; set; }
        public string subtotal { get; set; }
        public string subtotal_tax { get; set; }
        public string total { get; set; }
        public string total_tax { get; set; }
        public List<object> taxes { get; set; }
        public List<object> meta { get; set; }
    }
    
    public class ShippingLine
    {
        public int id { get; set; }
        public string method_title { get; set; }
        public string method_id { get; set; }
        public string total { get; set; }
        public string total_tax { get; set; }
        public List<object> taxes { get; set; }
    }
    
    public class RootObject
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string status { get; set; }
        public string order_key { get; set; }
        public int number { get; set; }
        public string currency { get; set; }
        public string version { get; set; }
        public bool prices_include_tax { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public int customer_id { get; set; }
        public string discount_total { get; set; }
        public string discount_tax { get; set; }
        public string shipping_total { get; set; }
        public string shipping_tax { get; set; }
        public string cart_tax { get; set; }
        public string total { get; set; }
        public string total_tax { get; set; }
        public Billing billing { get; set; }
        public Shipping shipping { get; set; }
        public string payment_method { get; set; }
        public string payment_method_title { get; set; }
        public string transaction_id { get; set; }
        public string customer_ip_address { get; set; }
        public string customer_user_agent { get; set; }
        public string created_via { get; set; }
        public string customer_note { get; set; }
        public string date_completed { get; set; }
        public string date_paid { get; set; }
        public string cart_hash { get; set; }
        public List<LineItem> line_items { get; set; }
        public List<object> tax_lines { get; set; }
        public List<ShippingLine> shipping_lines { get; set; }
        public List<object> fee_lines { get; set; }
        public List<object> coupon_lines { get; set; }
        public List<object> refunds { get; set; }
    }
