    public class ApEthMac
    {
        public string addr { get; set; }
    }
    
    public class ManagedBy
    {
        public string af { get; set; }
        public string addr { get; set; }
    }
    
    public class Radios
    {
        public string __invalid_name__radio_bssid.addr { get; set; }
    }
    
    public class ApLocation
    {
        public string ap_eth_mac { get; set; }
        public string campus_id { get; set; }
        public string building_id { get; set; }
        public string floor_id { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public double ap_x { get; set; }
        public double ap_y { get; set; }
    }
    
    public class ApIpAddress
    {
        public string af { get; set; }
        public string addr { get; set; }
        public int reboots { get; set; }
        public int rebootstraps { get; set; }
        public ManagedBy managed_by { get; set; }
        public string managed_by_key { get; set; }
        public Radios radios { get; set; }
        public bool is_master { get; set; }
        public ApLocation ap_location { get; set; }
    }
    
    public class Msg
    {
        public ApEthMac ap_eth_mac { get; set; }
        public string ap_name { get; set; }
        public string ap_group { get; set; }
        public string ap_model { get; set; }
        public string depl_mode { get; set; }
        public ApIpAddress ap_ip_address { get; set; }
        public int ts { get; set; }
    }
    
    public class AccessPointResult
    {
        public Msg msg { get; set; }
    }
    
    public class RootObject
    {
        public List<AccessPointResult> Access_point_result { get; set; }
    }
