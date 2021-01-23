    public Bitmap Base64ToBitmap(String base64String)
    {
        byte[] imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
        return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
    }
