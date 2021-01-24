     class Program
    {
        static void Main(string[] args)
        {
            Console.Write(GetFlipType("normal"));
        }
        static Dictionary<string, FlipType> FlipNameToType = new Dictionary<string, FlipType>();
        public static FlipType GetFlipType(string flipTypeName)
        {
            if (FlipNameToType == null || FlipNameToType.Count == 0)
            {
                FlipNameToType = default(FlipType).ToDictionaryMembersEx();
            }
            return FlipNameToType[flipTypeName];
        }
        public enum FlipType
        {
            normal,
            y4,
            x4,
            y4x4,
        }
    }
    public static class EnumExtensions
    {
        public static Dictionary<string, TEnum> ToDictionaryMembersEx<TEnum>(this TEnum source) where TEnum : struct, IConvertible
        {
            Dictionary<string, TEnum> dict = new Dictionary<string, TEnum>();
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                dict.Add(value.ToString(), value);
            }
            return dict;
        }
    }
