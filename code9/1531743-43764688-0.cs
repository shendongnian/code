    private string GetPathToImage(Android.Net.Uri uri) {
    	string doc_id = "";
    	using (var c1 = this.View.Context.ContentResolver.Query(uri, null, null, null, null)) {
    		c1.MoveToFirst();
    		String document_id = c1.GetString(0);
    		doc_id = document_id.Substring(document_id.LastIndexOf(":") + 1);
    	}
    
    	string path = null;
    
    	// The projection contains the columns we want to return in our query.
    	string selection = Android.Provider.MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
    	using (var cursor = this.Activity.ManagedQuery(Android.Provider.MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] { doc_id }, null)) {
    		if (cursor == null) return path;
    		var columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
    		cursor.MoveToFirst();
    		path = cursor.GetString(columnIndex);
    	}
    	return path;
    }
