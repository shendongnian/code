    public class NDCContract
    {
        public string ndc_id { get; set; }
        public string contract_num_val { get; set; }
        public decimal quote_price { get; set; }
        public DateTime eff_dt { get; set; }
        public DateTime  end_dt { get; set; }
        public decimal discount_pct { get; set; }
        public decimal rebate_pct { get; set; }
    }
