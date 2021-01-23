    public IEnumerable<Contact> Get()
    {
        for(int i = 1; i <= 5; i ++)
        {
           yield return GenerateRandomContact();
        }
    }
