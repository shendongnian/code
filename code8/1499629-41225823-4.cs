    public IEnumerable<Contact> Get(int number)
    {
        for(var i = 1; i <= number; i ++)  //is the same as for (var i = 1;; i++) you got the idea
        {
            yield return GenerateRandomContact();
        }
    }
