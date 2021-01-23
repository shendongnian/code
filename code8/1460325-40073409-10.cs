    BOOL fCast = FALSE;
    TypeHandle fromTypeHnd = obj->GetTypeHandle();
     if (fromTypeHnd.CanCastTo(toTypeHnd))
        {
            fCast = TRUE;
        }
    if (Nullable::IsNullableForType(toTypeHnd, obj->GetMethodTable()))
        {
            // allow an object of type T to be cast to Nullable<T> (they have the same representation)
            fCast = TRUE;
        }
        // If type implements ICastable interface we give it a chance to tell us if it can be casted 
        // to a given type.
        else if (toTypeHnd.IsInterface() && fromTypeHnd.GetMethodTable()->IsICastable())
        {
    	...
        }
     if (!fCast && throwCastException) 
        {
            COMPlusThrowInvalidCastException(&obj, toTypeHnd);
        } 
