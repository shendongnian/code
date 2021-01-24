		public void DidOutputMetadataObjects(AVCaptureMetadataOutput captureOutput,
		AVMetadataObject[] metadataObjects, AVCaptureConnection connection)
		{
			// dispose of the existing timer if there is one
			_timer?.Dispose();
			if (metadataObjects.OfType<AVMetadataFaceObject>() != null) {
				Button.Enabled = true;
			} else {
 				Button.Enabled = false;
			}
			// have the timer disable the button if no face is detected again
			_timer = new Timer(new TimerCallback((object state) => {
				InvokeOnMainThread(() => {
					Button.Enabled = true;
				});
			}), null, 150, Timeout.Infinite);
		}
