    public abstract class BitnameTypesBase
    {
        public abstract string ChaninName { get; }
        public string GET_BITNAME => "get_bit_name" + ChaninName;
        public string SEND_BITNAME => "send_bitname_" + ChaninName;
        public string QUERY_BITNAME => "query_bitname_" + ChaninName;
        public virtual string MySpecialAction => "special_bitname_" + ChaninName;
        public abstract class Of<T> : BitnameTypesBase where T : BitnameTypesBase, new()
        {
            public readonly static T Instance = new T();
        }
    }
    public sealed class BitcoinBitName : BitnameTypesBase.Of<BitcoinBitName>
    {
        public override string ChaninName => "bitcoin";
    }
    public sealed class OthercoinName : BitnameTypesBase.Of<OthercoinName>
    {
        public override string ChaninName => "something new";
    }
    //other coins defined similarly
