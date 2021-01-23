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
