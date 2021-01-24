    private void Slider_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
    {
        var slide= sender as Slider;
        Debug.WriteLine(slide.GetType().ToString());
        Debug.WriteLine(slide.Value+ ">>Slider_ManipulationCompleted");
    }
    
    private void Slider_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
    {
        var slide = sender as Slider;
        Debug.WriteLine(slide.GetType().ToString());
        Debug.WriteLine(slide.Value+ "Slider_ManipulationStarted");
    }
