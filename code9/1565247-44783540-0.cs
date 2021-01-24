    private void GetData()
    {
    	FirebaseDatabase
    		.Instance
    		.Reference
    		.Child("Put your child node name here")
    		.AddListenerForSingleValueEvent(new DataValueEventListener());
    }
    class DataValueEventListener: Java.Lang.Object, IValueEventListener
    {
    	public void OnCancelled(DatabaseError error)
    	{
    		// Handle error however you have to
    	}
    
    	public void OnDataChange(DataSnapshot snapshot)
    	{
    		if (snapshot.Exists())
            {
    			DataModelClass model = new DataModelClass();
    			var obj = snapshot.Children;
    
    			foreach (DataSnapshot snapshotChild in obj.ToEnumerable())
    			{
    				if (snapshotChild.GetValue(true) == null) continue;
    
    				model.PropertyName = snapshotChild.Child("Put your firebase attribute name here")?.GetValue(true)?.ToString();
    				model.PropertyName = snapshotChild.Child("Put your firebase attribute name here")?.GetValue(true)?.ToString();
    
    				// Use type conversions as required. I have used string properties only
    			}
    		}
    	}
    }
