    class Discount
    {
        public Decimal Amount { get; set; }
        public String Name { get; set; }
    }
    
    class Response
    {
       public Decimal Subtotal { get; set; }
       public Decimal Tax { get; set; }
       public List<Discount> Discount_section { get; set; }
       public Grand_total_incl_tax { get; set; } 
    }
    
    var response = JsonConvert.DeserializeObject<Response>(cart);
