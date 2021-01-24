    Issue 8
    Symptom
    ClickOnce applications targeting .NET Framework 4.0 that reference the Microsoft.Net.Http package may experience a TypeLoadException or other errors after being installed.
    Resolution
    This occurs because ClickOnce fails to deploy certain required assemblies. As a workaround, do the following:
    1.Right-click on the project and choose Add Existing Item
    2.Browse to the HttpClient net40 package folder
    3.In the File name text box enter *.*
    4.Holding CTRL, select System.Net.Http.dll and System.Net.Http.Primitives.dll
    5.Click the down-arrow next to the Add button and choose Add as Link
    6.In Solution Explorer, holding CTRL select System.Net.Http.dll and System.Net.Http.WebRequest.dll
    7.Right-click the selection, choose Properties and change Copy to Output Directory to Copy always
    8.Republish
