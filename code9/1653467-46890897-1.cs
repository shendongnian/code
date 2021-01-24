    public class Object<TId> where TId: class {
        public TId Id { get; set; }
        // Some other object properties...
    }
    public class ObjectReference<TId> where TId : class {
        public TId Id { get; set; }
    }
    public class ObjectStore<TId> where TId : class {
        private List<Object<TId>> _store = new List<Object<TId>>( );
        public Object<TId> FindByReference( ObjectReference<TId> reference ) {
            return _store.FirstOrDefault( x => x.Id == reference.Id );
        }
    }
