    public static List<T> GetSensors<T>(JToken jToken) where T : Sensor, new()
    {
        var sensors = new List<T>();
        try
        {
            foreach (var item in jToken)
            {
                var s = new T();
                s.Label = item["lab"].ToString();
                s.ActualTemp = item["tf"] != null ? item["tf"].ToString() : "";
                s.HighTemp = item["hf"] != null ? item["hf"].ToString() : "";
                s.LowTemp = item["lf"] != null ? item["lf"].ToString() : "";
                sensors.Add(s);
            }
        }
        catch (Exception)
        {
        }            
        return sensors;
    }
