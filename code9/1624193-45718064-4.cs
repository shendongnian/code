    using System.Linq;
    using System.Reflection;
    ...
    public Detector CreateDetector(string modelName, string ip, string port) {
      //TODO: validate modelName
      Type modelType = Assembly
        .GetExecutingAssembly() //TODO: check the assembly
        .GetTypes()
        .Where(t => t.Name == "Model" + modelName)
        .FirstOrDefault();
      if (null == modelType)
        return null; // Not found; you may want to throw exception here
      return modelType
        .GetConstructor(new Type[] {typeof(string), typeof(string)})
        .Invoke(new object[] {ip, port}) as Detector;
    }
