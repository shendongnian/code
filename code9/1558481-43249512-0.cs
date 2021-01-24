    class A : IDisposable {
        B _b;
        A(B b) { b.Register(this); _b = b; }
        void IDisposable.Dispose() { _b = null; }
        void CheckDisposed() { if(_b == null) throw new ObjectDisposedException(nameof(A)); }
        public void ActualMethod() {
            CheckDisposed();
            // do stuff
        }
    }
    class B : IDisposable {
        A _a;
        internal void Register(A a) {
            if(a == null) throw new ArgumentNullException(nameof(a));
            if(_a != null) throw new InvalidOperationException("already has an A");
            _a = a;
        }
        void IDisposable.Dispose() {
            var tmp = _a;
            _a = null;
            tmp?.Dispose();
        }
    }
