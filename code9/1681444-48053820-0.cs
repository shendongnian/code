    public class AssetRecord: //IEquatable<AssetRecord> left as exercise
    {   
        // Custom data type. Each object has time and price
        public DateTime AssetDate { get; set; } 
        public decimal AssetPrice { get; set; }
        public override bool ToString(object other) =>
            other is AssetRecord ass && 
                (ass.AssetDate == AssetDate &&
                 ass.AssetPrice == AssetPrice);                
        public override int GetHashCode() =>
           AssetDate.GetHashCode() ^ AssetPrice.GetHashCode();
    }
