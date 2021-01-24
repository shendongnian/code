    using System.Reflection;
    
    ...
    
    public Detector CreateDetector(string modelName, string ip, string port) {
        //TODO: validate modelName
        Dictionary<string, Detector> detectors = new Dictionary<string, Detector>()
        {
            { "A", typeof(ModelA) },
            { "B", typeof(ModelB) },
            ...
        };
       
        return detectors[modelName]
          .GetConstructor(new Type[] {typeof(string), typeof(string)})
          .Invoke(new object[] {ip, port}) as Detector;
    }
