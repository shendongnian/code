         public stream checkSymbolExistJson(string pSymbol)
      {
            Person p    = new Person();
            p.name      = pSymbol;
            p.age       = 15;
    
        string json = JsonConvert.SerializeObject(p);
        return new MemoryStream(Encoding.UTF8.GetBytes(json));
      }
