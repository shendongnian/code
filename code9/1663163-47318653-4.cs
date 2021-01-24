    public IHttpActionResult Post(RootData value)
    {
        if (value != null && value.Choices != null)
        {
            foreach (var valueChoice in value.Choices)
            {
                int theNumber = valueChoice.Key;
                FoodItem foodItem = valueChoice.Value;
                var name = foodItem.Name;
                var id   = foodItem.Id;
            }
        }
        return Ok("All good");
    }
