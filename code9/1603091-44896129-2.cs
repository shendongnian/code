    public string GetRealFilePath(Uri uri)
    {
        var isDocumentUri = DocumentsContract.IsDocumentUri(this, uri);
        if (isDocumentUri)
        {
            string id = DocumentsContract.GetDocumentId(uri);
            string[] split = id.Split(':');
            string type = split[0];
            if (IsMediaDocument(uri))
            {
                Uri contentUri = null;
                if ("image".Equals(type))
                {
                    contentUri = MediaStore.Images.Media.ExternalContentUri;
                    string selection = "_id=?";
                    string[] selectionArgs = new string[] { split[1] };
                    string filePath = GetDataColumn(this, contentUri, selection, selectionArgs);
                    return filePath;
                }
            }
        }
        return null;
    }
    public  string GetDataColumn(Context context, Uri uri, string selection,string[] selectionArgs)
    {
    
        ICursor cursor = null;
        string column = "_data";
        string[] projection = {
            column
        };
    
        try
        {
            cursor = ContentResolver.Query(uri, projection, selection, selectionArgs,
                    null);
            if (cursor != null && cursor.MoveToFirst())
            {
                int column_index = cursor.GetColumnIndexOrThrow(column);
                return cursor.GetString(column_index);
            }
        }
        finally
        {
            if (cursor != null)
                cursor.Close();
        }
        return null;
    }
    public static bool IsMediaDocument(Uri uri)
    {
        return "com.android.providers.media.documents".Equals(uri.Authority);
    }
