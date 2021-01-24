    class BackgroundWorkerException : Exception
    {
        public string Sernum { get; }
        public BackgroundWorkerException(string sernum, Exception inner)
            : base("DoWork event handler threw an exception", inner)
        {
            Sernum = sernum;
        }
    }
