    private void CaptureMyScreen()
    {
          try
          {
               //Creating a new Bitmap object
              Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
            
             //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
             //Creating a Rectangle object which will  
             //capture our Current Screen
             Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
     
             //Creating a New Graphics Object
             Graphics captureGraphics = Graphics.FromImage(captureBitmap);
     
            //Copying Image from The Screen
            captureGraphics.CopyFromScreen(captureRectangle.Left,captureRectangle.Top,0,0,captureRectangle.Size);
     
            //Saving the Image File (I am here Saving it in My E drive).
            captureBitmap.Save(@"E:\Capture.jpg",ImageFormat.Jpeg);
     
            //Displaying the Successfull Result
     
            MessageBox.Show("Screen Captured");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
