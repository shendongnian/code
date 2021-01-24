        private async void CreateVisuals()
        {
            var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            var bitmap = await CanvasBitmap.LoadAsync(CanvasDevice.GetSharedDevice(),
                new Uri("ms-appx:///Assets/Wave-PNG-Transparent-Picture.png"));
            var drawingSurface =
                CanvasComposition.CreateCompositionGraphicsDevice(compositor, CanvasDevice.GetSharedDevice())
                    .CreateDrawingSurface(bitmap.Size,
                        DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);
            using (var ds = CanvasComposition.CreateDrawingSession(drawingSurface))
            {
                ds.Clear(Colors.Transparent);
                ds.DrawImage(bitmap);
            }
            var surfaceBrush = compositor.CreateSurfaceBrush(drawingSurface);
            surfaceBrush.Stretch = CompositionStretch.None;
            var maskedBrush = compositor.CreateMaskBrush();
            maskedBrush.Mask = Ellipse.GetAlphaMask();
            maskedBrush.Source = surfaceBrush;
            var sprite = compositor.CreateSpriteVisual();
            sprite.Size = new Vector2((float)Ellipse.Width, (float)Ellipse.Height);
            sprite.Brush = maskedBrush;
            sprite.CenterPoint = new Vector3(sprite.Size / 2, 0);
            sprite.Scale = new Vector3(0.9f);
            ElementCompositionPreview.SetElementChildVisual(VisualBorder, sprite);
            var offsetAnimation = compositor.CreateScalarKeyFrameAnimation();
            offsetAnimation.InsertKeyFrame(0, 0);
            offsetAnimation.InsertKeyFrame(1, 256, compositor.CreateLinearEasingFunction());
            offsetAnimation.Duration = TimeSpan.FromMilliseconds(1000);
            offsetAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
            surfaceBrush.StartAnimation("Offset.X", offsetAnimation);
        }
    }
