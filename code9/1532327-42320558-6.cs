    private void PopulateMap(List<Places> places)
    {
      for (int index = 0; index < places.Count; index++)
      {
        var pinDecorator = new PinDecorator
        {
          Pin = new Pin
          {
            Type = PinType.Place,
            Position = new Position(places[index].Lat, places[index].Lon),
            Label = places[index].Name,
            Address = places[index].Address
          },
          Index = index
        };
    
        pinDecorator.Pin.Clicked += OnPinClicked;
    
        MyMap.Pins.Add(pinDecorator.Pin);
      }
    }
