    public static Byte[] CompressDataSet(DataSet dataSet)
    {
        using (MemoryStream inputStream = new MemoryStream())
        using (MemoryStream resultStream = new MemoryStream())
        using (GZipStream gzipStream = new GZipStream(resultStream, CompressionMode.Compress))
        {
            dataSet.WriteXml(inputStream, XmlWriteMode.WriteSchema);
            inputStream.Seek(0, SeekOrigin.Begin);
            inputStream.CopyTo(gzipStream);
            
            gzipStream.Close();
            
            return resultStream.ToArray();
        }
    }
    
    public static DataSet DecompressDataSet(Byte[] data)
    {
        using (MemoryStream compressedStream = new MemoryStream(data))
        using (GZipStream gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        using (DataSet dataset = new DataSet())
        {
            dataset.ReadXml(gzipStream, XmlReadMode.ReadSchema);
            return dataset;
        }
    }
