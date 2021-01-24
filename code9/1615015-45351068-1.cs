    originClient.GetListingAsync(FTPOriginPath).ContinueWith(t =>
       {
          foreach (var item in t.Result)
          {
             if (item.Name.EndsWith("_RDY"))
             {
             originClient.DownloadFileAsync(DestinationPath + item.Name.Substring(0, 4), item.FullName.Substring(0, 4), true).ContinueWith(tt =>
              {
                  Log.Info(item.Name.Substring(0, 4) + " DOWNLOAD: OK");
                  originClient.DeleteFile(item.FullName); // of course you would have to adjust this call to the correct name of a method that deletes a file
              }, System.Threading.Tasks.TaskContinuationOptions.OnlyOnRanToCompletion).Wait();
             }
           }
       }, System.Threading.Tasks.TaskContinuationOptions.OnlyOnRanToCompletion).Wait();
