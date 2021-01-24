    public abstract class BaseClass
    {
        public ObjectState ObjectState { get; private set; }
    
        protected bool Set<T>( ref T field, T value )
        {
            if Equals( field, value ) return false;
            field = value;
            if ( ObjectState == ObjectState.Unchanged )
              ObjectState = ObjectState.Changed;
            return true;
        }
    }
