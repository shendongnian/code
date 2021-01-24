    // argument removed here ------------------------------\/
    public static async Task<bool> StartSingleAppService<T>() where T : Service
    {
        // GetServiceMaintainer() gets a singleton of my Services list
        if (ServiceMaintainer.GetServiceMaintainer() != null)
        {
            Service service = ServiceMaintainer
                .GetServiceMaintainer()
                .FindServiceByType(typeof(T));
            // argument changed here --/\
            if (await ServiceMaintainer.StartService(service))
            {
                return true;
            }
        }
        return false;
    }
