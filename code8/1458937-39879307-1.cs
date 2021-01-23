    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    /// <param name="disposing">
    ///   <c>true</c> to release both managed and unmanaged resources; 
    ///   <c>false</c> to release only unmanaged resources.
    /// </param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            lock (_synchRoot)
            {
                while (_items.Count > 0)
                {
                    var item = _items.Pop();
                    item.Dispose();
                }
                _items = null;
            }
        }
        base.Dispose(disposing);
    }
