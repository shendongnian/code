    private void updateBackground(MenuSelect _menu)
        {
            // Check Background
            if (!String.IsNullOrEmpty(_menu.BackGround))
            {
                // Web Client Object
                using (var objClient = new WebClient())
                {
                    try
                    {
                        // Download Image
                        String szUrlAddress = String.Format("http://my_site.com/t_server/download.php?token={0}", _menu.BackGround);
                        byte[] imgData = objClient.DownloadData(szUrlAddress);
                        if (imgData.Length > 0)
                        {
                            using (var objStream = new MemoryStream(imgData))
                            {
                                // Create Bitmap Image
                                var myBitmapImg = new BitmapImage();
                                myBitmapImg.BeginInit();
                                myBitmapImg.StreamSource = objStream;
                                myBitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                                myBitmapImg.EndInit();
                                myBitmapImg.Freeze();
                                // Create Image
                                Image myImage = new Image();
                                myImage.Source = myBitmapImg;
                                // Create Image Brush
                                ImageBrush myBrush = new ImageBrush();
                                myBrush.ImageSource = myImage.Source;
                                // Set Background
                                this.Background = myBrush;
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        log("Background Exception: \"" + ex.Message);
                    }
                }
            }
        }
		
    private void selectMenu(MenuSelect _menu)
            {
    ...
    ...
    ...
     Manager.Instance.selectMenu(_menu);
     updateBackground(_menu);
     
     ...
     ...
     }
		
		
    <TextBlock Text="Select Menu:" Foreground="White" VerticalAlignment="Center" Grid.Column="2" Margin="16,0,0,0"/>
                <ComboBox Name="menuComboBox" Width="Auto" Margin="8,0,0,0" VerticalAlignment="Center" Grid.Column="3"
                          IsEnabled="{Binding IsChecked, Converter={StaticResource InverseBooleanConverter}, ElementName=enableButton}" 
                          SelectionChanged="menuComboBox_SelectionChanged"/>	
