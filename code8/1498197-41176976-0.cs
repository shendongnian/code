        public IEnumerator<T> GetEnumerator ()
        {
            if (!_deferred)
                return GenerateCommand("*").ExecuteQuery<T>().GetEnumerator();
            return GenerateCommand("*").ExecuteDeferredQuery<T>().GetEnumerator();
        }
       
