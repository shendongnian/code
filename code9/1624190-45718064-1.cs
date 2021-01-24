    using System.Reflection;
    
    ...
    
    //DONE: do not recreate the dictionary, but create it once as a static field
    static Dictionary<string, Detector> detectors = new Dictionary<string, Detector>() {
      { "A", typeof(ModelA) },
      { "B", typeof(ModelB) },
       ...
    };
    public Detector CreateDetector(string modelName, string ip, string port) {
      //TODO: validate modelName
       
      return detectors[modelName]
        .GetConstructor(new Type[] {typeof(string), typeof(string)})
        .Invoke(new object[] {ip, port}) as Detector;
    }
