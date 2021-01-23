    var controller = new PriceFeedController {Request = new HttpRequestMessage()};
    controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey,
        new HttpConfiguration());
    controller.Request.Properties.Add("sample_property",
        "plaintext string to pass to Get() method on PriceFeed");
    var result = controller.Get(100, 105);
