      RestUrl = http://developer.xamarin.com:8081/api/todoitems/
      var uri = new Uri (RestUrl);
      ...
      var response = await client.GetAsync (uri);
      if (response.IsSuccessStatusCode) {
          var content = await response.Content.ReadAsStringAsync ();
          Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
      }
