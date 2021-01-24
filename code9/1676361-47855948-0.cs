    public static string getBusesJson()
        {
            var buses = new List<Bus>();
            buses.Add(new Bus() {latitude = 10, longitude = 20 });
            buses.Add(new Bus() { latitude = 15, longitude = 30 });
            buses.Add(new Bus() { latitude = 5, longitude = 40 });
            return JsonConvert.SerializeObject(buses);
        }
