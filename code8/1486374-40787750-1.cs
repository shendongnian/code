    [ProtoContract]
    public class CultureInfoSurrogate
    {
        [ProtoMember(1)]
        public int CultureId { get; set; }
        public static implicit operator CultureInfoSurrogate(CultureInfo culture)
        {
            if (culture == null) return null;
            var obj = new CultureInfoSurrogate();
            obj.CultureId = culture.LCID;
            return obj;
        }
        public static implicit operator CultureInfo(CultureInfoSurrogate surrogate)
        {
            if (surrogate == null) return null;
            return new CultureInfo(surrogate.CultureId);
        }
    }
