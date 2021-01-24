    foreach (var sensor in hardwareItem.Sensors)
    {
        if (sensor.SensorType == SensorType.Temperature)
        {
            Console.WriteLine(sensor.Value.ToString());
            Console.WriteLine(sensor.Identifier.ToString() + ":" + sensor.Value.ToString());
        }
    }
