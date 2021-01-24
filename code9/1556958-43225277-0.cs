    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        try
        {
            Bitmap bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Jpeg,100, stream);
                byte[] array=stream.ToArray();
            }
                    
        }
        catch (Java.IO.IOException e)
        {
               //Exception Handling
        }
    }
