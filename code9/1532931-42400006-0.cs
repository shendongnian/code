         var tr = new Trip
                    {
                        Triptype = provider.FormData.GetValues("trip").FirstOrDefault(),
                        Options = provider.FormData.GetValues("options").FirstOrDefault(),
                        Seat = provider.FormData.GetValues("seat").FirstOrDefault(),
                };
