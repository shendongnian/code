    private async void bntCapture_Click(object sender, RoutedEventArgs e)
    {
        for (int j = 1; j <= 30; j++)
        {
            string path = Directory.GetCurrentDirectory();
            string em_cap_original_path = System.IO.Path.Combine(path, "Database");
            imgCapture.Source = imgVideo.Source;
            Helper.SaveImageCapture((BitmapSource)imgCapture.Source, em_cap_original_path, j);
            await Task.Delay(20);//Delay in ms
        }
        MessageBox.Show("Images created");
    }
