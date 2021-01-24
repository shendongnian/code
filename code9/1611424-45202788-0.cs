    public class BAModel
    {
        public string mfg_site_OID { get; set; }
        public string mfg_site_id { get; set; }
    }
    
    mfg_site_OID = Convert.ToBase64String(new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 })
