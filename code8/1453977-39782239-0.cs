    [TestMethod]
    public void DynamicDeserialization() {
        var json = "{\"message\":\"Hi\"}";
        dynamic jsonResponse = JsonConvert.DeserializeObject(json);
        dynamic d = JObject.Parse(json);
        Assert.IsTrue(d.message.ToString() == "Hi");
        Assert.IsTrue(jsonResponse.message.ToString() == "Hi");
    }
