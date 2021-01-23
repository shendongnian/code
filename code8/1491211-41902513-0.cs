    private async void ReleaseCapture()
       // Release the resources used for capturing photo.
       {
       try
          {
          captureElement.Source = null;
          await this.captureMgr.StopPreviewAsync();
          //////////////
          // Don't dispose it. Otherwise, when we re-initialize it right after we have released it, the program will
          // crash. We are better off don't do this here. When we are leaving the page, the page will release it
          // anyway.
          //////////////
          //this.captureMgr.Dispose();
          /////////////////////////////
          }
       catch( Exception ex )
          {
          String sErrMsg = String.Concat( "Fail to release resources related to the ",
                                          "use of the camera. The error message is: ",
                                          ex.Message );
          await new MessageDialog( sErrMsg, "Error" ).ShowAsync();
          }
       }
