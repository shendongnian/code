     StorageFile timelineCMPOutputFile = await ApplicationData.Current.LocalFolder.GetFileAsync("timelineCMPOutputFile");
     StorageFile timelineCMPOutputFile2 = await ApplicationData.Current.LocalFolder.GetFileAsync("timelineCMPOutputFile2");
     var composition = await MediaComposition.LoadAsync(timelineCMPOutputFile);
     var composition2 = await MediaComposition.LoadAsync(timelineCMPOutputFile2);
     //TODO: Warn user to select the oldest first.
     try
     {
         await composition2.RenderToFileAsync(await ApplicationData.Current.LocalFolder.CreateFileAsync("temp.mp4", CreationCollisionOption.ReplaceExisting));
         StorageFile tempfile = await ApplicationData.Current.LocalFolder.GetFileAsync("temp.mp4");
         MediaClip firstClip = await MediaClip.CreateFromFileAsync(tempfile);            
         composition.Clips.Add(firstClip); /// Exception throws here.
     }
     catch (Exception ex)
     {
         System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
     }
     var action = composition.SaveAsync(timelineCMPOutputFile);
     // Combine two video files together into one
 
