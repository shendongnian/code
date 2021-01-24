    using (var isolated = new Isolated<Client>()) {
       string response = isolated.Value.GetResponse(url);
    }
  
 
