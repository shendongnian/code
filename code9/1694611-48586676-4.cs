    public class NullRepository : IMasterRepository {
        public static readonly IMasterRepository Empty = new NullRepository();
        public NullRepository () { }
        //...implement members that do nothing and may return empty collections.
    }
