    var picker = ELCImagePickerViewController.Create();
    picker.MaximumImagesCount = 15;
    
    picker.Completion.ContinueWith (t => {
      if (t.IsCanceled || t.Exception != null) {
        // no pictures for you!
      } else {
         var items = t.Result as List<AssetResult>;
       }
    });
    
    PresentViewController (picker, true, null);
