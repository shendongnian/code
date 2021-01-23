     public bool MoveNext() {
       ...
       return MoveNextRare()
     } 
     private bool MoveNextRare()
     {                
       if (version != list._version) {
         ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
     }
