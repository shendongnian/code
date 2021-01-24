        public virtual void Close()
        {
            /* These are correct, but we'd have to fix PipeStream & NetworkStream very carefully.
            Contract.Ensures(CanRead == false);
            Contract.Ensures(CanWrite == false);
            Contract.Ensures(CanSeek == false);
            */
 
            Dispose(true);
            GC.SuppressFinalize(this);
        }
