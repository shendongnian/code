    interface IMain<TSub, TPart, TSubPart>
        where TSubPart : ISubPart<TSub, TPart, TSubPart>
        where TSub : ISub<TSub, TPart, TSubPart>
        where TPart : IPart<TSub, TPart, TSubPart>
    {
        ICollection<TSub> Subs { get; set; }
    }
    interface ISub<TSub, TPart, TSubPart>
        where TSub : ISub<TSub, TPart, TSubPart>
        where TPart : IPart<TSub, TPart, TSubPart>
        where TSubPart : ISubPart<TSub, TPart, TSubPart>
    {
        ICollection<TSubPart> SubParts { get; set; }
    }
    interface IPart<TSub, TPart, TSubPart>
        where TPart : IPart<TSub, TPart, TSubPart>
        where TSub : ISub<TSub, TPart, TSubPart>
        where TSubPart : ISubPart<TSub, TPart, TSubPart>
    {
        ICollection<TSubPart> SubParts { get; set; }
    }
    interface ISubPart<TSub, TPart, TSubPart>
        where TSubPart : ISubPart<TSub, TPart, TSubPart>
        where TSub : ISub<TSub, TPart, TSubPart>
        where TPart : IPart<TSub, TPart, TSubPart>
    {
        TSub Sub { get; set; }
        TPart Part { get; set; }
    }
    class SubPart : ISubPart<Sub, Part, SubPart>
    {
        public long Id { get; set; }
        public Sub Sub { get; set; }
        public Part Part { get; set; }
    }
    class Sub : ISub<Sub, Part, SubPart>
    {
        public long Id { get; set; }
        public ICollection<SubPart> SubParts { get; set; }
    }
    class Part : IPart<Sub, Part, SubPart>
    {
        public long Id { get; set; }
        public ICollection<SubPart> SubParts { get; set; }
    }
    class Main : IMain<Sub, Part, SubPart>
    {
        public long Id { get; set; }
        public ICollection<Sub> Subs { get; set; }
    }
    class MyContext : DbContext
    {
        public DbSet<Main> MainEntities { get; set; }
    }
