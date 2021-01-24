    public void DeserializerPopulatesFavoriteColorFromOldFavoriteColor()
    {
        var json = @"{ favoriteColor: ""Green""}";
        var deserialized = JsonConvert.DeserializeObject<Example>(json, new ExampleConverter());
        Assert.AreEqual("Green", deserialized.oldFavoriteColor);
        Assert.AreEqual(deserialized.oldFavoriteColor, deserialized.favoriteColor);
    }
