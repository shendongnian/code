    public class AssetRecord: //IEquatable<AssetRecord> left as exercise
    {   
        // Custom data type. Each object has time and price
        public DateTime AssetDate { get; set; } 
        public decimal AssetPrice { get; set; }
        public override bool ToString(object other)
        {
             if (other is AssetRecord)
             {
                 var ass = (AssetRecord)other;
                 return ass.AssetDate == AssetDate &&
                        ass.AssetPrice == AssetPrice;  
             }
             return false;
        }              
        public override int GetHashCode()
        {
            return AssetDate.GetHashCode() ^ AssetPrice.GetHashCode();
        }
    }
