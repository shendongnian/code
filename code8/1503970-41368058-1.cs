      //On initialize form :
            WebClient client = new WebClient();
    
       //On start download :
    
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(url), @"C:\Temp\TestingSatelliteImagesDownload\" + ExtractImages.imagesUrls[currentImageIndex] + ".jpg");
     ...
            void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
            {
    if(currentImageIndex<ImageToDownloadCount){
    currentImageIndex +=1;
            client.DownloadFileAsync(new Uri(url), @"C:\Temp\TestingSatelliteImagesDownload\" + ExtractImages.imagesUrls[currentImageIndex] + ".jpg");
    }
    
                label1.Text = "Completed";
                count++;
            }
      
 
