    Task.Run(async () =>
            {
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                map.MoveToRegion (MapSpan.FromCenterAndRadius (
                new Position (position.Longitude, position.Latitude), Distance.FromMiles (1))); // current pos
                //var position = new Position(-26.077740, 28.010100); // Latitude, Longitude
                var pin = new Pin {
                    Type = PinType.Place,
                    //Position = position,
                    Label = "Test",
                    Address = "Test..."
                };
                map.Pins.Add(pin);
            });
