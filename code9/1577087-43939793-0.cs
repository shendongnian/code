    internal enum videosinktype { glimagesink, d3dvideosink, dshowvideosink, directdrawsink}
    static Element mVideoTestSource, mVideoCaps, mVideoSink, mAppQueue, mVideoConv;
    static Gst.App.AppSink mAppSink;
    static System.Threading.Thread mMainGlibThread;
    static GLib.MainLoop mMainLoop;  // GLib's Main Loop
    private const videosinktype mCfgVideosinkType = videosinktype.dshowvideosink;
    private ulong mHandle;
    private Gst.Video.VideoSink mGlImageSink;
    private Gst.Pipeline mCurrentPipeline = null;
	private void InitGStreamerPipeline()
	{
		//Assign Handle to prevent Cross-Threading Access
		mHandle = (ulong)videoDisplay.Handle;
		
		//Init Gstreamer
		Gst.Application.Init();    
		GtkSharp.GstreamerSharp.ObjectManager.Initialize();
		
		mMainLoop = new GLib.MainLoop();
		mMainGlibThread = new System.Threading.Thread(mMainLoop.Run);
		mMainGlibThread.Start();
		
		#region BuildPipeline	
		switch (mCfgVideosinkType)
		{
			case videosinktype.glimagesink:
				mGlImageSink = (Gst.Video.VideoSink)Gst.ElementFactory.Make("glimagesink", "glimagesink");
				break;
			case videosinktype.d3dvideosink:
				mGlImageSink = (Gst.Video.VideoSink)Gst.ElementFactory.Make("d3dvideosink", "d3dvideosink");
				//mGlImageSink = (Gst.Video.VideoSink)Gst.ElementFactory.Make("dshowvideosink", "dshowvideosink");
				break;  
			case videosinktype.dshowvideosink:
				mGlImageSink = (Gst.Video.VideoSink)Gst.ElementFactory.Make("dshowvideosink", "dshowvideosink");
				break;
			case videosinktype.directdrawsink:
				mGlImageSink = (Gst.Video.VideoSink)Gst.ElementFactory.Make("directdrawsink", "directdrawsink");
				break;
			default:
				break;
		}
		
		mVideoTestSource = ElementFactory.Make("videotestsrc", "videotestsrc0");
		mVideoConv = ElementFactory.Make("videoconvert", "vidconvert0");
		mVideoSink = ElementFactory.Make("autovideosink", "sink0");
			
		mCurrentPipeline = new Gst.Pipeline("pipeline");	
		mCurrentPipeline.Add(mVideoTestSource, mVideoConv, mVideoSink, mGlImageSink);
		
		if (!mVideoTestSource.Link(mVideoSink))
		if (mUdpcSrc.Link(mVideoSink))            
		{
			System.Diagnostics.Debug.WriteLine("Elements could not be linked");
		}
		#endregion
		
		//subscribe to bus & bussync msgs
		Bus bus = mCurrentPipeline.Bus;
		bus.AddSignalWatch();
		bus.Message += HandleMessage;
		
		Bus bus = mCurrentPipeline.Bus;
		bus.EnableSyncMessageEmission();
		bus.SyncMessage += new SyncMessageHandler(bus_SyncMessage);
		
		//play the stream
		var setStateRet = mCurrentPipeline.SetState(State.Null);
		System.Diagnostics.Debug.WriteLine("SetStateNULL returned: " + setStateRet.ToString());
		setStateRet = mCurrentPipeline.SetState(State.Ready);
		System.Diagnostics.Debug.WriteLine("SetStateReady returned: " + setStateRet.ToString());
		setStateRet = mCurrentPipeline.SetState(Gst.State.Playing);	
	}
	 /// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Indeed the application needs to set its Window identifier at the right time to avoid internal Window creation
	/// from the video sink element. To solve this issue a GstMessage is posted on the bus to inform the application
	/// that it should set the Window identifier immediately.
	/// 
	/// API: http://gstreamer.freedesktop.org/data/doc/gstreamer/head/gst-plugins-base-libs/html/gst-plugins-base-libs-gstvideooverlay.html
	/// </remarks>
	/// <param name="o"></param>
	/// <param name="args"></param>
	private void bus_SyncMessage(object o, SyncMessageArgs args)
	{
		//Convenience function to check if the given message is a "prepare-window-handle" message from a GstVideoOverlay.
		System.Diagnostics.Debug.WriteLine("bus_SyncMessage: " + args.Message.Type.ToString());
		if (Gst.Video.Global.IsVideoOverlayPrepareWindowHandleMessage(args.Message))
		{
			Element src = (Gst.Element)args.Message.Src;
	#if DEBUG
			System.Diagnostics.Debug.WriteLine("Message'prepare-window-handle' received by: " + src.Name + " " + src.ToString());
	#endif
			if (src != null && (src is Gst.Video.VideoSink | src is Gst.Bin))
			{
				//    Try to set Aspect Ratio
				try
				{
					src["force-aspect-ratio"] = true;
				}
				catch (PropertyNotFoundException) { }
				//    Try to set Overlay
				try
				{
					Gst.Video.VideoOverlayAdapter overlay_ = new Gst.Video.VideoOverlayAdapter(src.Handle);
					overlay_.WindowHandle = mHandle;                        
					overlay_.HandleEvents(true);
				}
				catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Exception thrown: " + ex.Message); }
			}
		}
	}
	private void HandleMessage (object o, MessageArgs args)
	{
		var msg = args.Message;
		//System.Diagnostics.Debug.WriteLine("HandleMessage received msg of type: {0}", msg.Type);
		switch (msg.Type)
		{
			case MessageType.Error:
				//
				GLib.GException err;
				string debug;
				System.Diagnostics.Debug.WriteLine("Error received: " + msg.ToString());
				//msg.ParseError (out err, out debug);
				//if(debug == null) { debug = "none"; }
				//System.Diagnostics.Debug.WriteLine ("Error received from element {0}: {1}", msg.Src, err.Message);
				//System.Diagnostics.Debug.WriteLine ("Debugging information: "+ debug);
				break;
			case MessageType.StreamStatus:
				Gst.StreamStatusType status;
				Element theOwner;
				msg.ParseStreamStatus(out status, out theOwner);
				System.Diagnostics.Debug.WriteLine("Case SteamingStatus: status is: " + status + " ; Ownder is: " + theOwner.Name);
				break;
			case MessageType.StateChanged:
				//System.Diagnostics.Debug.WriteLine("Case StateChanged: " + args.Message.ToString());
				State oldState, newState, pendingState;
				msg.ParseStateChanged(out oldState, out newState, out pendingState);
				if (newState == State.Paused)
					args.RetVal = false;
				System.Diagnostics.Debug.WriteLine("Pipeline state changed from {0} to {1}: ; Pending: {2}", Element.StateGetName(oldState), Element.StateGetName(newState), Element.StateGetName(pendingState));
				break;
			case MessageType.Element:
				System.Diagnostics.Debug.WriteLine("Element message: {0}", args.Message.ToString());
				break;                
			default:
				System.Diagnostics.Debug.WriteLine("HandleMessage received msg of type: {0}", msg.Type);
				break;
		}
		args.RetVal = true;
	}
