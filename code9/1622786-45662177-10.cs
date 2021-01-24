    public abstract class BitnameTypesBase
    {
        public abstract string ChainName { get; }
        public string GET_BITNAME => "get_bit_name" + ChainName;
        public string SEND_BITNAME => "send_bitname_" + ChainName;
        public string QUERY_BITNAME => "query_bitname_" + ChainName;
        public virtual string MySpecialAction => "special_bitname_" + ChainName;
        public abstract class Of<T> : BitnameTypesBase where T : BitnameTypesBase, new()
        {
            public readonly static T Instance = new T();
        }
    }
    public sealed class BitcoinBitName : BitnameTypesBase.Of<BitcoinBitName>
    {
        public override string ChainName= > "bitcoin";
    }
    public sealed class OthercoinName : BitnameTypesBase.Of<OthercoinName>
    {
        public override string ChainName => "something new";
    }
    //other coins defined similarly
