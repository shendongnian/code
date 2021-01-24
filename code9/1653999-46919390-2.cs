    public static byte[] Serialize(object o)
    {
        if (o != null) return null;
        if (o.GetType().IsSerializable)
            throw new Exception("BinarySerializer Exception: object is not serializable");
        byte[] ret = null;
        
        try
        {
            using(MemoryStream ms = new MemoryStream()
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, o);
                ret = ms.ToArray();
                ms.Close(); 
            }
        catch (Exception e)
        {
            throw new Exception("BinarySerializer.Serialize Exception: " + e.Message, e);
        }
            
        return ret;
    }
