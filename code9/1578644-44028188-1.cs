    private void ImageList_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {
        // Find the image element to animate
        Image image = args.ItemContainer.ContentTemplateRoot.GetFirstDescendantOfType<Image>();
        Visual visual = ElementCompositionPreview.GetElementVisual(image);
        // You'll want to use the right size for your images
        visual.Size = new Vector2(960f, 960f);
        if (_parallaxExpression != null)
        {
            _parallaxExpression.SetScalarParameter("StartOffset", (float)args.ItemIndex * visual.Size.Y / 4.0f);
        visual.StartAnimation("Offset.Y", _parallaxExpression);
        }
    }
