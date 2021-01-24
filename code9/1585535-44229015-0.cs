            /// <summary> A non-UI, retaining-instance fragment to internally handle downloading files. </summary>
            public class DownloadFragment : Fragment
            {
                /// <summary> The tag to identify this fragment. </summary>
                internal new const string Tag = nameof(DownloadFragment);
   
                public override void OnCreate(Bundle savedInstanceState)
                {
                    base.OnCreate(savedInstanceState);
                    RetainInstance = true;
                }
    
                /// <summary> Starts the given download. </summary>
                public async void RunDownload(Context context, Download download, IDownloadListener listener,
                    IDownloadNotificationHandler handler = null)
                {
                    // start your async download here, and hook listeners. 
                    // Note that listener calls will happen on the UI thread.
                }
            }
