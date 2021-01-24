    public void Create(Product product)
    {
      var request = new RestRequest("Products", Method.POST); < ----- Use Method.PUT for update
      request.AddJsonBody(product);
      client.Execute(request);
    }
