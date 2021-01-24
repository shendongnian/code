     using Windows.UI.Xaml.Hosting;
     //'this' is MainPage, but can be any UIElement
     var visual = ElementCompositionPreview.GetElementVisual(this);
     var brush = visual.Compositor.CreateHostBackdropBrush();
     var sprite = visual.Compositor.CreateSpriteVisual();
     sprite.Brush = brush;
     //Set to the size of the area, update on SizeChanged
     sprite.Size = new System.Numerics.Vector2(1000, 1000); 
     ElementCompositionPreview.SetElementChildVisual(this, sprite);
