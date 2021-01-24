    private static byte[] ConvertToBytes(HttpPostedFileBase file)
    {
        int fileSizeInBytes = file.ContentLength;
        byte[] data = null;
        using (var br = new BinaryReader(file.InputStream))
        {
            data = br.ReadBytes(fileSizeInBytes);
        }
        return data;
    }
