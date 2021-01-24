    dynamic responseDeserializeObject = HttpGetResponse(endPoint);
    foreach (var event in responseDeserializeObject.result[0].EventType.events.Local.Events)
    {
      var value = event.Value;
      Console.Writeline(value.Venue);
      Console.Writeline(value.StateCode);
      Console.Writeline(value.CountryCode);
    }
