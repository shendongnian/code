    private void chart1_AnnotationPositionChanging(object sender,
                                                   AnnotationPositionChangingEventArgs e)
    {
        if (e.Annotation == slider)
        {
            chart1.ChartAreas[0].Position.Height = (float)slider.Y - 4;
            chart1.ChartAreas[1].Position.Height = (float)(100f - slider.Y) - 4;
            chart1.ChartAreas[1].Position.Y = (float)slider.Y;
            chart1.Update();
        }
    }
