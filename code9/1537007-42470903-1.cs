    private async void ButtonClicked(object sender, MouseButtonEventArgs e) // async after private
    {
         Image button = (Image)sender;
         buttons[button.Name].Source = ImageResizer.ResizeImage(System.Drawing.Image.FromFile(@"D:\buttons\" + button.Name + ".png"), buttonSize);
         await Task.Delay(2000);
         NavigationService.Navigate(new UpgradeQuiz());
    }
