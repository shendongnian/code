    public static async Task ShipAsync(this Exception exception, HttpContext context)
    {
        var elmahIoConfig = context.RequestServices.GetService<ElmahIoConfiguration>();
        await MessageShipper.ShipAsync(
            elmahIoConfig.ApiKey,
            elmahIoConfig.LogId,
            exception.Message, context, new ElmahIoSettings(), exception);
    }
