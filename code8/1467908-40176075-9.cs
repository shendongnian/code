      HttpClient _myClient =new HttpClient();
      internal Task<string> LoadCompanyContractsAsync(string URL)
      {
          ....
          return _myClient.GetStringAsync(new Uri(URL))
                          .ConfigureAwait(false);
      }
    }
