    public class P3
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class P6
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class P12
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class P
    {
        public P3 P3 { get; set; }
        public P6 P6 { get; set; }
        public P12 P12 { get; set; }
    }
    
    public class C3
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class C6
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class C12
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class MEMBERSHIP
    {
        public P P { get; set; }
        public C3 C3 { get; set; }
        public C6 C6 { get; set; }
        public C12 C12 { get; set; }
    }
    
    public class NCP3
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class NCP6
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class NCP12
    {
        public string NAME { get; set; }
        public string CALL { get; set; }
        public string DURATION { get; set; }
        public string OFFER_PRICE { get; set; }
    }
    
    public class RootObject
    {
        public string MTONGUE { get; set; }
        public string REGISTERED { get; set; }
        public string MULTI_PROFILE { get; set; }
        public string PAID { get; set; }
        public string __invalid_name__INFO_DTOFBIRTH  { get; set; }
        public string INFO_GENDER { get; set; }
        public string INFO_MSTATUS { get; set; }
        public string INFO_RELIGION { get; set; }
        public string RENEWAL { get; set; }
        public string RENEWAL_DAYS { get; set; }
        public string DISCOUNT_TEXT { get; set; }
        public string DISCOUNT_PERCENT { get; set; }
        public MEMBERSHIP MEMBERSHIP { get; set; }
        public NCP3 NCP3 { get; set; }
        public NCP6 NCP6 { get; set; }
        public NCP12 NCP12 { get; set; }
    }
