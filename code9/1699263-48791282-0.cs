    async void RevertPhoto(object sender, EventArgs e)
     {
          //Update Database here
    
          await HandleFileAsync();
     }
     async Task HandleFileAsync()
        {
            await ResaveFile();
         
                
                PicturePlaceholder.Controls.Clear(); //Clear the pictures on the next page
                GetPhotoInfo(Convert.ToInt32(hiddenICTASKID.Value)); //Reload pictures on next page
    
                showPanels(PanelPhotoReview); //Show the panel while hiding the rest.
                hidePanels(PanelCleanList, PanelSiteList, PanelImageSwap, Panel5, PanelRevertPhoto, PanelImageDelete);
            
        }
         async Task ResaveFile()
            {
                await Task.Factory.StartNew(() =>
                {
                    if (File.Exists(RevertFolderPath.Value)) //These two lines shouldn't be necessary as WriteAllBytes will overwrite.
                        File.Delete(RevertFolderPath.Value);
        
                    string filePath = RevertFolderPath.Value;
                    File.WriteAllBytes(filePath, Convert.FromBase64String(Base64RevertImage.Value));
                });
            }
