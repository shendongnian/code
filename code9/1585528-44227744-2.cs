    if (logger.IsEnabled(LogLevel.Information))
    {
        logger.LogInformation($"Putting {id}");
    }
    if (logger.IsEnabled(LogLevel.Trace))
    {
        logger.LogTrace("Putting model {0}", Newtonsoft.Json.JsonConvert.SerializeObject(model));
    }
