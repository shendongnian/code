    public async Task Handle(Client client)
    {
      while (true)
      {
        var data = await client.ReadAsync();
        Task.Run(async () => {
          try { await this.ProcessData(client, data); }
          catch (Exception ex) {
            // TODO: handle
          }
        });            
      }
    }
