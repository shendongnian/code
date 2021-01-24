    	public void Add(object val){
    		(this as ICollection<object>).Add(val);	    		
    	}
    	
    	#region Explicit ICollection<T> implementation
    		
    	void ICollection<object>.Add(object val){
    		// some code to add the object	
    	}
    	#endregion
    }
