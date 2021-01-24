    public static async Task ShipAsync(this Exception exception, HttpContext context)
    {
        await MessageShipper.ShipAsync(
            ElmahIoMiddleware.ApiKey.AssertApiKeyInMiddleware(),
            ElmahIoMiddleware.LogId.AssertLogIdInMiddleware(),
            exception.Message, context, new ElmahIoSettings(), exception);
    }
