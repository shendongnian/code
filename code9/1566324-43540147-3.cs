        private void manualCapture_Click(object sender, RoutedEventArgs e)
        {
            if (captureImage != null)
            {
                captureImage(latestFrame);
            }
            Bitmap bm = BitmapImage2Bitmap(latestFrame);
            bm.Save(@"C:\tmp\test.jpg", ImageFormat.Jpeg);
        }
