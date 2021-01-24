    public abstract class ApiResponse
    {
        public Meta meta { get; set; }
    }
    
    public class AccountApiResponse : ApiResponse
    {
        public AccountData data { get; set; }
    }
    
    public class ShipmentApiResponse : ApiResponse
    {
        public ShipmentData data { get; set; }
    }
