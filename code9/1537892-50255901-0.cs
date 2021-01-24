    	public void Add(object val){
    		// some code to add the object	
    	}
    	
    	#region Explicit ICollection<T> implementation
    		
    	void ICollection<object>.Add(object val){
    		// Call the instance method
    		this.Add(val);	
    	}
    	#endregion
    }
