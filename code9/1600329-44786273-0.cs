    public Candidate Get(Guid id)
    {
        try
        {
            return _repository.Find(id);
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
