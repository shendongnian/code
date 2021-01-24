    private void LoadData()
    {
        var assembly = typeof(MapPage).GetTypeInfo().Assembly;
        foreach (var res in assembly.GetManifestResourceNames())
        {
            if(res.Contains("data.txt"))
            {
                Stream stream = assembly.GetManifestResourceStream(res);
                using (var reader = new StreamReader(stream))
                {
                    string data = "";
                    while((data = reader.ReadLine()) != null)
                    {        
                        var array = data.Split(' ');
                        dataArray.Add(new SensorModel()
                        {
                            left = Convert.ToInt32(array[0]),
                            right = Convert.ToInt32(array[1]),
                            front = Convert.ToInt32(array[2])
                        });
                    }
                }
            }
        }
    }
