.ConfigureLogging((context, logging) => {
    foreach (ServiceDescriptor serviceDescriptor in logging.Services)
    {
        if (serviceDescriptor.ImplementationType == typeof(Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider))
        {
            // remove ConsoleLoggerProvider service only
            logging.Services.Remove(serviceDescriptor);
            break;
        }
    }
    // now you can register any new logging provider service; e.g.,
    logging.AddLog4Net();
    logging.AddEventSourceLogger();
})
