    var filename = "file.pdf";
    var file = System.IO.Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).ToString(), filename);
    var uri = Android.Net.Uri.Parse(file);
    
    Intent intent = new Intent(Intent.ActionView);
    intent.SetFlags(ActivityFlags.ClearTop);
    intent.SetDataAndType(uri, "application/pdf");
    try
    {
        StartActivity(intent);
    }
    catch (ActivityNotFoundException e)
    {
        Toast.MakeText(Application.Context, "Install a pdf viewer.", ToastLength.Long).Show();
    }
