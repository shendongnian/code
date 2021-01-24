	var data = new RootObject()
	{
		Stations = new Stations()
		{
			From = new List<Station>()
			{
				new Station()
				{
					Id = "008501120",
					Name = "Lausanne",
					Score = 101,
					Coordinate = new Coordinate()
					{
						Type = "WGS84",
						X = 46.516777,
						Y = 6.629095
					},
					Distance = null
				}
			},
			To = new List<Station>()
			{
				new Station()
				{
					Id = "000000178",
					Name = "Fribourg",
					Score = null,
					Coordinate = new Coordinate()
					{
						Type = "WGS84",
						X = 46.803272,
						Y = 7.151027
					},
					Distance = null
				}
			}
		}
	};
	
	var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
