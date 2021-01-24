    bool _isDone = false;
    public bool IsDone
    {
        get
        {
            System.Threading.Thread.MemoryBarrier();
            var toReturn = this._isDone;
            System.Threading.Thread.MemoryBarrier();
            return toReturn;
        }
        private set
        {
            System.Threading.Thread.MemoryBarrier();
            this._isDone = value;
            System.Threading.Thread.MemoryBarrier();
        }
    }
