    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _object1?.Dispose();
            _object2?.Dispose();
        }
    }
