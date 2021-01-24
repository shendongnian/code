    var client = db.Clients.FirstOrDefault(c=> c.Id = someid); //get a client
    if (client != null)
    {
        cardCount = client.Cards.Count;
    }
