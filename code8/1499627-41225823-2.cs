    public IEnumerable<Contact> Get(int number)
    {
        for(var i = 1; true; i ++)  //is the same as for (var i = 1;; i++) you got the idea
        {
           if(i== number)
              yield break;
           yield return GenerateRandomContact();
        }
    }
