    public class JustOnceOrElseEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> decorated;
        public JustOnceOrElseEnumerable(IEnumerable<T> decorated)
        {
            this.decorated = decorated;
        }
        private bool CalledAlready;
        public IEnumerator<T> GetEnumerator()
        {
            if (CalledAlready)
                throw new Exception("Enumerated already");
            CalledAlready = true;
            return decorated.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (CalledAlready)
                throw new Exception("Enumerated already");
            CalledAlready = true;
            return decorated.GetEnumerator();
        }
    }
