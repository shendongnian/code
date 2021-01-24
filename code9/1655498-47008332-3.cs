    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        if (requestCode == 0)
        {
            var uri = data.Data;
            string path = GetActualPathFromFile(uri);
            System.Diagnostics.Debug.WriteLine("Image path == " + path);
                
        }
    }
    
