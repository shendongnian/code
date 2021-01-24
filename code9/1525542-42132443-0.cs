    private void CPtest_ColorChanged(object sender, Windows.UI.Color color)
    {
        ink.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;
        // Set initial ink stroke attributes.
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        drawingAttributes.Color = color;
        drawingAttributes.IgnorePressure = false;
        drawingAttributes.FitToCurve = true;
        ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        W_Paints.Visibility = W_Paints.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        this.ink.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;
    }
