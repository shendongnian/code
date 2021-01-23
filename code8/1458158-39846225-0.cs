    private static DriverConfig<T> DeserialiseDriverConfig<T>(string _json, string _driverTransport)
    {
        switch (_driverTransport)
        {
            case "serial-device":
                try
                {
                    SerialDriverConfig<T> _serialDriverConfig = JsonConvert.DeserializeObject<SerialDriverConfig<T>>(_json);
                    if (_serialDriverConfig != null)
                    {
                        return _serialDriverConfig;
                    }
                }
                catch (Exception e)
                {
                    //Blah blah blah
                }
                break;
        }
        return null;
    }
