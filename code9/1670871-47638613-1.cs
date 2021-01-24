    var req = new List<RequestData> // Again I use list, could be an array
    {
        new RequestData
        {
            id = "0e740d9c-571c-44f4-b796-7c40c0e20a1d",
            points = new List<points> // Defined as a list, even though it has one entry
            {
                new points
                {
                    timestamp = DateTime.UtcNow,
                    value = number.Next(100, 99999)
                }
            }
        }
    };
