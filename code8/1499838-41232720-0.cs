    public bool Remove(T item) {
       lock( this.sync ) {
          int index = this.InternalIndexOf( item );
          if( index < 0 )
             return false;
    
          this.RemoveItem( index );
          return true;
       }
    }
    protected virtual void RemoveItem(int index) {
       this.items.RemoveAt( index );
    }
    public void RemoveAt(int index) {
       lock( this.sync ) {
          if( index < 0 || index >= this.items.Count )
             throw DiagnosticUtility.ExceptionUtility.ThrowHelperError( new ArgumentOutOfRangeException( "index", index,
                                              SR.GetString( SR.ValueMustBeInRange, 0, this.items.Count - 1 ) ) );
    
    
          this.RemoveItem( index );
       }
    }
