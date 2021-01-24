    private async Task<Card> FindCardForCustomerAsync(string customer)
    {
      var account = await _service.FindAccountAsync(customer);
      return await _service.FindCardAsync(account);
    }
    
    public async Task<Data> FindCustomersWithCards(string[] customers)
    {
      var cardsTasks = customers.Select(FindCardForCustomerAsync);
      var cards = await Tasks.WhenAll(cardsTasks)
      …
    }
