        private PixelShaderEffect _textureShader;
        private GaussianBlurEffect _blur;
        private BlendEffect _blend;
        private void AnimatedControl_OnCreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }
        private async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Shaders/TextureTest.bin"));
            var buffer = await FileIO.ReadBufferAsync(file);
            var sourceImage = await CanvasBitmap.LoadAsync(sender, new Uri("ms-appx:///Assets/image.jpg"));
            _textureShader = new PixelShaderEffect(buffer.ToArray())
            {
                Source1 = sourceImage
            };
            _blur = new GaussianBlurEffect
            {
                BlurAmount = 4,
                Source = _textureShader
            };
            _blend = new BlendEffect
            {
                Foreground = _blur,
                Background = sourceImage,
                Mode = BlendEffectMode.Color
            };
        }
        private void AnimatedControl_OnDraw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.DrawImage(_blend);
        }
        private void RangeBase_OnValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            _textureShader.Properties["threshold"] = (float)e.NewValue / 100;
        }
        private void ColorSpectrum_OnColorChanged(ColorSpectrum sender, ColorChangedEventArgs args)
        {
            _textureShader.Properties["sourceColor"] = new Vector3((float)args.NewColor.R / 255, (float)args.NewColor.G / 255, (float)args.NewColor.B / 255);
        }
        private void ColorSpectrum_OnColorChanged1(ColorSpectrum sender, ColorChangedEventArgs args)
        {
            _textureShader.Properties["replaceColor"] = new Vector3((float)args.NewColor.R / 255, (float)args.NewColor.G / 255, (float)args.NewColor.B / 255);
        }
