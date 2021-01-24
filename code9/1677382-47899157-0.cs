    public class AssetBase
    {
        public string MappingId { get; set; }
        public bool IsActive { get; set; }        
    }
    public class Asset : AssetBase
    {
        public string AssetId { get; set; }
    }
    public class Util : AssetBase
    {
        public string UtilId { get; set; }
    }
    static void Main(string[] args)
    {
        string id = Console.ReadLine();
        
        if (Regex.Match(id, "^[A-Z][a-zA-Z]*$").Success)
        {
            Asset asset = new Asset();
            asset.AssetId = id;
        }
        else
        {
            Util util = new Util();
            util.UtilId = id;
        }
    }
