        // Clones this ArrayList, doing a shallow copy.  (A copy is made of all
        // Object references in the ArrayList, but the Objects pointed to 
        // are not cloned).
        public virtual Object Clone()
        {
            Contract.Ensures(Contract.Result<Object>() != null);
            ArrayList la = new ArrayList(_size);
            la._size = _size;
            la._version = _version;
            Array.Copy(_items, 0, la._items, 0, _size);
            return la;
        }
