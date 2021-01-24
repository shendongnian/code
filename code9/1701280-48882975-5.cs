    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        var uri = data.Data;
        ICursor cursor = this.ContentResolver.Query(uri, null, null, null, null);
        cursor.MoveToFirst();
        var filenameIndex = cursor.GetColumnIndex("_display_name");
        var filename = cursor.GetString(filenameIndex);
        System.Diagnostics.Debug.WriteLine("filename == " + filename);
    }
