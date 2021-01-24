    String pathAndFile = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;    
    pathAndFile = Path.GetDirectoryName(pathAndFile);
    Uri uri = new Uri(pathAndFile);
    pathAndFile = uri.LocalPath + "\\" + "Microsoft.Office.Interop.Excel.Dll";
    compilerParams.ReferencedAssemblies.Add(pathAndFile);
