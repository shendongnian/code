    private async void _timer_Tick(object sender, object e)
    {
        try
        {
            var temp     = await _bme280.ReadTemperature();
            Debug.WriteLine("Temp: {0} deg C", temp);
            var humidity = _bme280.ReadHumidity();
            var pressure = _bme280.ReadPressure();
            var altitude = _bme280.ReadAltitude(seaLevelPressure);
        } 
        catch
        {
            Debug.WriteLine("Cannot read values from sensor...");
        }
    }
