    public byte[] downloadTemplate(string excelFileName)
        //...
        byte[] modelData = toByteArray(stream);
        return modelData;
    }
    public byte[] toByteArray(System.IO.Stream stream)
    {
        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        {
            stream.CopyTo(ms);
            return ms.ToArray();
        }
    }
