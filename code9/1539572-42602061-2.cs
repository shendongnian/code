    var index = new ProductNameIndex();
    try
    {
        Serializer.Merge(stream, index);
    }
    catch (Exception ex)
    {
        // Log the error
        Debug.WriteLine(ex);
    }
