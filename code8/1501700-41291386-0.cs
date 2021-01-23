    //use CodeBase instead of Location because of Shadow Copy.
    string codebase = Assembly.GetExecutingAssembly().CodeBase;
    var vUri = new UriBuilder(codebase);
    string vPath = Uri.UnescapeDataString(vUri.Path + vUri.Fragment);
    string directory = Path.GetDirectoryName(vPath);
    if (!string.IsNullOrEmpty(vUri.Host)) directory = @"\\" + vUri.Host + directory;
    DllLocation = Path.Combine(directory, "Resources\\MyDll.dll");
