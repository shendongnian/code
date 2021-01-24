    if (Intent.Action == Intent.ActionSend)
    {
         ClipData clip = Intent.ClipData;
         Uri uri = clip.GetItemAt(0).Uri;
         ICursor returnCursor = ContentResolver.Query(uri, null, null, null, null);
         int nameIndex = returnCursor.GetColumnIndex(OpenableColumns.DisplayName);
         returnCursor.MoveToFirst();
         var fileName = returnCursor.GetString(nameIndex);
         Toast.MakeText(this,"fileName == " + fileName, ToastLength.Short).Show();
    }    
