    using (var context = new MyContext()) 
    { 
         var client = context.Client.Find(clientId); 
 
         // Count how many cards the client has  
         var cardsCount = context.Entry(client) 
                          .Collection(b => b.Cards) 
                          .Query() 
                          .Count(); 
    }
