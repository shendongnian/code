    [Serializable]
    class Emp
    {
      public int id {get;set;}
      public int Name {get;set;}
      public List<cardType> cardTypes {get;set;}
    
    }
    [Serializable]
    class cardType
    {
      public int name {get;set;}
      public DateTime Expiry {get;set;}
    
    }
