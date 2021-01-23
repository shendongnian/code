    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
    string myVersion = assembly.GetName().Version + ".";
    int major = int.Parse(myVersion.Split('.')[0]); // Get the major version number
    int minor = int.Parse(myVersion.Split('.')[1]); // Get the minor version number
    myVersion += (major | (minor << 16)) + ""; // Append the rest
