    if (Intent.Action == Intent.ActionSend)
    {
        ClipData clip = Intent.ClipData;
        Uri uri = clip.GetItemAt(0).Uri;
        string path = uri.Path;
        var fileName = System.IO.Path.GetFileName(path);
        System.Diagnostics.Debug.WriteLine("fileName == " + fileName);
    }
