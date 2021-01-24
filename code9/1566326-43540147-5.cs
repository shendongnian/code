        private void manualCapture_Click(object sender, RoutedEventArgs e)
        {
            if (captureImage != null)
            {
                captureImage(latestFrame);
            }
            Bitmap bm = BitmapImageToBitmap(latestFrame);
            bm.Save(@"C:\tmp\test.jpg", ImageFormat.Jpeg);
        }
