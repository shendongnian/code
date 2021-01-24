    private void SeekSlider_PointerCaptureLost(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        Slider slider = sender as Slider;
        if (slider != null)
        {
            //mediaPlayer.Position = (float)slider.Value;
        }
    }
