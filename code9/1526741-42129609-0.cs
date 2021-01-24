    public void Send()
    {
    
    
        Bitmap b = BitmapFactory.DecodeResource(Resources,Resource.Drawable.icon_120);
    
        var tempFilename = "test.png";
        var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        var filePath = System.IO.Path.Combine(sdCardPath, tempFilename);
        using (var os = new FileStream(filePath, FileMode.Create))
        {
            b.Compress(Bitmap.CompressFormat.Png, 100, os);
        }
        b.Dispose ();
    
        var imageUri = Android.Net.Uri.Parse ($"file://{sdCardPath}/{tempFilename}");
        var sharingIntent = new Intent ();
        sharingIntent.SetAction (Intent.ActionSend);
        sharingIntent.SetType ("image/*");
        
        sharingIntent.PutExtra (Intent.ExtraStream, imageUri);
        sharingIntent.AddFlags (ActivityFlags.GrantReadUriPermission);
        StartActivity (Intent.CreateChooser (sharingIntent, "choose"));}
