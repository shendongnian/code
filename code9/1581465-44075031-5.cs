    public void Delete(int id)
    {
      var request = new RestRequest("Products/" + id, Method.DELETE);
      client.Execute(request);
    }
