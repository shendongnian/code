    var assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
    var assemblyFolder = System.IO.Path.GetDirectoryName(assemblyLocation);
    var file = System.IO.Path.Combine(assemblyFolder , "test.py");
    if (!System.IO.File.Exists(file))
        System.IO.File.WriteAllBytes(file, Properties.Resources.test);
