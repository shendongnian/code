    dynamic responseDeserializeObject = HttpGetResponse(endPoint);
    foreach (var ev in responseDeserializeObject.result[0].EventType.events.Local.Events)
    {
      var value = ev.Value;
      Console.WriteLine(value.Venue);
      Console.WriteLine(value.StateCode);
      Console.WriteLine(value.CountryCode);
    }
