    public byte[] GetBinaryImage(int Id)
    {
        byte[] result = context.People.Where(a => a.Id == Id).Select(a => a.PersonImage).SingleOrDefault();
        return result;
    }
