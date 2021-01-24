    dynamic responseDeserializeObject = HttpGetResponse(endPoint);
    foreach (var ev in responseDeserializeObject.result[0].EventType.events.Local.Events)
    {
      var value = ev.Value;
      Console.Writeline(value.Venue);
      Console.Writeline(value.StateCode);
      Console.Writeline(value.CountryCode);
    }
