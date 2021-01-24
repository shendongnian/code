public class MockAsyncCursor<T> : IAsyncCursor<T>
{
    private readonly IEnumerable<T> _items;
    private bool called = false;
    public MockAsyncCursor(IEnumerable<T> items)
    {
        _items = items ?? Enumerable.Empty<T>();
    }
    public IEnumerable<T> Current => _items;
    public bool MoveNext(CancellationToken cancellationToken = new CancellationToken())
    {
        return !called && (called = true);
    }
    public async Task<bool> MoveNextAsync(CancellationToken cancellationToken)
    {
        return !called && (called = true);
    }
    public void Dispose()
    {
    }
}
