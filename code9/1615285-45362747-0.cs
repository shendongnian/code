    public class MyClass {
        private readonly CollectionView _View;
        public CollectionView View { get { return _View; } }
        public MyClass() {
            this._View = ...;
        }
    }
