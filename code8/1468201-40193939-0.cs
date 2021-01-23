    interface IMain<TSub, TSubPart>
        where TSubPart : ISubPart<TSubPart>
        where TSub : ISub<TSubPart>
    {
        ICollection<TSub> Subs { get; set; }
    }
    interface ISub<TSubPart>
        where TSubPart : ISubPart<TSubPart>
    {
        ICollection<TSubPart> SubParts { get; set; }
    }
    interface IPart<TSubPart>
        where TSubPart : ISubPart<TSubPart>
    {
        ICollection<TSubPart> SubParts { get; set; }
    }
    interface ISubPart<TSelf>
        where TSelf : ISubPart<TSelf>
    {
        ISub<TSelf> Sub { get; set; }
        IPart<TSelf> Part { get; set; }
    }
    class SubPart : ISubPart<SubPart>
    {
        public long Id { get; set; }
        public ISub<SubPart> Sub { get; set; }
        public IPart<SubPart> Part { get; set; }
    }
    class Sub : ISub<SubPart>
    {
        public long Id { get; set; }
        public ICollection<SubPart> SubParts { get; set; }
    }
    class Part : IPart<SubPart>
    {
        public long Id { get; set; }
        public ICollection<SubPart> SubParts { get; set; }
    }
    class Main : IMain<Sub, SubPart>
    {
        public long Id { get; set; }
        public ICollection<Sub> Subs { get; set; }
    }
    class MyContext : DbContext
    {
        public DbSet<Main> MainEntities { get; set; }
    }
