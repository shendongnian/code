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
            void DownloadFileAsync(string address, string filename);
        }
    
        [ComVisible(true)]
        [Guid("56C41646-10CB-4188-979D-23F70E0FFDF5")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComSourceInterfaces(typeof(IEvents))]
        [ProgId("COMVisibleEvents.DemoEvents")]
        public class DemoEvents : IDemoEvents
        {
            public delegate void OnDownloadCompletedDelegate();
            private event OnDownloadCompletedDelegate OnDownloadCompleted;
            public string _address { get; private set; }
            public string _filename { get; private set; }
    
            public void DownloadFileAsync(string address, string filename)
            {
                _address = address;
                _filename = filename;
    
                // Uncomment to get real implementation:
                //System.Net.WebClient wc = new System.Net.WebClient();
                //Task.Factory.StartNew(() => wc.DownloadFile(_address, _filename))
                //    .ContinueWith(t =>
                //    {
                        if (null != this.OnDownloadCompleted)
                            OnDownloadCompleted();
                    //});
            }
        }
    }
