	void HandleGalleryButtonClick ()
	{
		if (galleryImagePicker == null) {
			galleryImagePicker = new UIImagePickerController ();
			galleryImagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			galleryImagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes (UIImagePickerControllerSourceType.PhotoLibrary);
			galleryImagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
			galleryImagePicker.Canceled += Handle_Canceled;
		}
		PresentViewController (galleryImagePicker, true, () => { });
	}
	void HandleCameraButtonClick ()
	{
		if (cameraImagePicker == null) {
			cameraImagePicker = new UIImagePickerController ();
			cameraImagePicker.PrefersStatusBarHidden ();
			cameraImagePicker.SourceType = UIImagePickerControllerSourceType.Camera;
			cameraImagePicker.FinishedPickingMedia += Handle_FinishedPickingCameraMedia;
			cameraImagePicker.Canceled += Handle_CameraCanceled;
		}
		PresentViewController (cameraImagePicker, true, () => { });
	}
	void Handle_Canceled (object sender, EventArgs e)
	{
		galleryImagePicker.DismissViewController (true, () => { });
	}
	protected void Handle_FinishedPickingMedia (object sender, UIImagePickerMediaPickedEventArgs e)
	{
		// determine what was selected, video or image
		bool isImage = false;
		switch (e.Info [UIImagePickerController.MediaType].ToString ()) {
		case "public.image":
			Console.WriteLine ("Image selected");
			isImage = true;
			break;
		case "public.video":
			Console.WriteLine ("Video selected");
			break;
		}
		// get common info (shared between images and video)
		var referenceURL = e.Info [new NSString ("UIImagePickerControllerReferenceUrl")] as NSUrl;
		if (referenceURL != null)
			Console.WriteLine ("Url:" + referenceURL);
		// if it was an image, get the other image info
		if (isImage) {
			// get the original image
			var originalImage = e.Info [UIImagePickerController.OriginalImage] as UIImage;
			if (originalImage != null) {
					// do something with the image
				Console.WriteLine ("got the original image");
				Picture.Image = originalImage; // Picture is the ImageView
				picAssigned = true;
			}
		} else { // if it's a video
			 // get video url
			var mediaURL = e.Info [UIImagePickerController.MediaURL] as NSUrl;
			if (mediaURL != null) {
				Console.WriteLine (mediaURL);
			}
		}
		// dismiss the picker
		galleryImagePicker.DismissViewController (true, () => { });
	}
	protected void Handle_FinishedPickingCameraMedia (object sender, UIImagePickerMediaPickedEventArgs e)
	{
		// determine what was selected, video or image
		bool isImage = false;
		switch (e.Info [UIImagePickerController.MediaType].ToString ()) {
		case "public.image":
			Console.WriteLine ("Image selected");
			isImage = true;
			break;
		case "public.video":
			Console.WriteLine ("Video selected");
			break;
		}
		// get common info (shared between images and video)
		var referenceURL = e.Info [new NSString ("UIImagePickerControllerReferenceUrl")] as NSUrl;
		if (referenceURL != null)
			Console.WriteLine ("Url:" + referenceURL);
		// if it was an image, get the other image info
		if (isImage) {
			// get the original image
			var originalImage = UIHelper.RotateCameraImageToProperOrientation (e.Info [UIImagePickerController.OriginalImage] as UIImage, 320);
			if (originalImage != null) {
				// do something with the image
				Console.WriteLine ("got the original image");
				Picture.Image = originalImage; // display
				picAssigned = true;
			}
		} else { // if it's a video
			 // get video url
			var mediaURL = e.Info [UIImagePickerController.MediaURL] as NSUrl;
			if (mediaURL != null) {
				Console.WriteLine (mediaURL);
			}
		}
		// dismiss the picker
		cameraImagePicker.DismissViewController (true, () => { });
	}
	void Handle_CameraCanceled (object sender, EventArgs e)
	{
		cameraImagePicker.DismissViewController (true, () => { });
	}
