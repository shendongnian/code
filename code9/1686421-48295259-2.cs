    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        if (requestCode == 0)
        {
            var uri = data.Data;
 
            System.IO.Stream image_stream = ContentResolver.OpenInputStream(uri);
            Bitmap getBitmap = BitmapFactory.DecodeStream(image_stream);
        }
    }
