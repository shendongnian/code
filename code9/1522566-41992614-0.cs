    public interface IMapper
    {
        IContract Get(object input);
        IEnumerable<IContract> Get(params object[] input);
    }
