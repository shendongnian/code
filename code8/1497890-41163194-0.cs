    [ComVisible(true)]
    [Guid("56C41646-10CB-4188-979D-23F70E0FFDF5")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("COMVisibleEvents.DemoEvents")]
    public class DemoEvents : ServicedComponent, IDemoEvents
    {
        public async Task DownloadFileAsync(string address, string filename)
        { ... }
    }
