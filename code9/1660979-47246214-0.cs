    public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
    
            //KVO for outputVolume
            var session = AVAudioSession.SharedInstance();
            var errorOrNull = session.SetActive (true);
            if (errorOrNull != null) {
                //TODO: ...handle it
            }
            session.AddObserver (this, "outputVolume", NSKeyValueObservingOptions.New, IntPtr.Zero);
    
    
        }
    
        public override void ObserveValue (NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
        {
                       //TODO: Filter as appropriate, error-handling, etc.
            var volume = (float) (change ["new"] as NSNumber);
    
            volumeLabel.Text = volume.ToString();
        }
