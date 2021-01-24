    private void SetupAnimation()
    {
        // available with SDK version 15063
        Compositor compositor = Window.Current.Compositor;
        // available with previous SDK version
        //Compositor compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
        // Get scrollviewer using UWP Community Toolkit extension method
        ScrollViewer myScrollViewer = ImageList.FindDescendant<ScrollViewer>();
        _scrollProperties = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScrollViewer);
        // Setup the expression
        var scrollPropSet = _scrollProperties.GetSpecializedReference<ManipulationPropertySetReferenceNode>();
        var startOffset = ExpressionValues.Constant.CreateConstantScalar("startOffset", 0.0f);
        var parallaxValue = 0.5f;
        var parallax = (scrollPropSet.Translation.Y + startOffset);
        _parallaxExpression = parallax * parallaxValue - parallax;
    }
