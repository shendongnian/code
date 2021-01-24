    public class BitnameTypesBase
    {
        public static string ChainName;
    
        public static string GET_BITNAME = "get_bitname_" + ChainName;
        public static string SEND_BITNAME = "send_bitname_" + ChainName;
        public static string QUERY_BITNAME = "query_bitname_" + ChainName;
    }
    
    public class BitcoinBitName :  BitnameTypesBase
    {
        public static new string ChainName = "Bitcoin";
    	public static string MySpecialAction = "special_bitname_" + ChainName;
    }
    
    public class OthercoinBitName : BitnameTypesBase
    {
    	public static new string ChainName = "something new";
    	public static string MySpecialAction = "special_bitname_" + ChainName;
    }
