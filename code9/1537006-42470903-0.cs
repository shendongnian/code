    private async void ButtonClicked(object sender, MouseButtonEventArgs e) // async after private
    {
         Image button = (Image)sender;
         buttons[button.Name].Source = ImageResizer.ResizeImage(System.Drawing.Image.FromFile(@"D:\buttons\" + button.Name + ".png"), buttonSize);
         await Task.Delay(200);
         NavigationService.Navigate(new UpgradeQuiz());
    }
