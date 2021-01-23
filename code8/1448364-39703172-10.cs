    using System;
    using System.EnterpriseServices;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    
    namespace COMVisibleEvents
    {
        [ComVisible(true)]
        [Guid("8403C952-E751-4DE1-BD91-F35DEE19206E")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IEvents
        {
            [DispId(1)]
            void OnDownloadCompleted();
        }
    
        [ComVisible(true)]
        [Guid("2BF7DA6B-DDB3-42A5-BD65-92EE93ABB473")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IDemoEvents
        {
            [DispId(1)]
            Task DownloadFileAsync(string address, string filename);
        }
    
        [ComVisible(true)]
        [Guid("56C41646-10CB-4188-979D-23F70E0FFDF5")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComSourceInterfaces(typeof(IEvents))]
        [ProgId("COMVisibleEvents.DemoEvents")]
        public class DemoEvents
            : ServicedComponent, IDemoEvents
        {
            public delegate void OnDownloadCompletedDelegate();
            private event OnDownloadCompletedDelegate OnDownloadCompleted;
            public string _address { get; private set; }
            public string _filename { get; private set; }
            private readonly string _downloadToDirectory = 
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
            public async Task DownloadFileAsync(string address, string filename)
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Credentials = new NetworkCredential(
                            "user", "psw", "domain");
                        string file = Path.Combine(_downloadToDirectory, filename);
                        await webClient.DownloadFileTaskAsync(new Uri(address), file)
                            .ContinueWith(t =>
                            {
                                // https://stackoverflow.com/q/872323/
                                var ev = OnDownloadCompleted;
                                if (ev != null)
                                {
                                    ev();
                                }
                            }, TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
                catch (Exception ex)
                {
                    // Log exception here ...
                }
            }
        }
    }
