    public class AsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public AsyncEnumerable(Expression expression)
            : base(expression) { }
    
        public IAsyncEnumerator<T> GetEnumerator() =>
            new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }
    
    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;
    
        public AsyncEnumerator(IEnumerator<T> enumerator) =>
            this.enumerator = enumerator ?? throw new ArgumentNullException();
    
        public T Current => enumerator.Current;
    
        public void Dispose() { }
    
        public Task<bool> MoveNext(CancellationToken cancellationToken) =>
            Task.FromResult(enumerator.MoveNext());
    }
    [Fact]
    public async Task TestEFCore()
    {
        var data =
            new List<Entity>()
            {
                new Entity(),
                new Entity(),
                new Entity()
            }.AsQueryable();
        var mockDbSet = new Mock<DbSet<Entity>>();
        mockDbSet.As<IAsyncEnumerable<Entity>>()
            .Setup(d => d.GetEnumerator())
            .Returns(new AsyncEnumerator<Entity>(data.GetEnumerator()));
        mockDbSet.As<IQueryable<Entity>>().Setup(m => m.Provider).Returns(data.Provider);
        mockDbSet.As<IQueryable<Entity>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<Entity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<Entity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        var mockCtx = new Mock<SomeDbContext>();
        mockCtx.SetupGet(c => c.Entities).Returns(mockDbSet.Object);
        var entities = await mockCtx.Object.Entities.ToListAsync();
        Assert.NotNull(entities);
        Assert.Equal(3, entities.Count());
    }
