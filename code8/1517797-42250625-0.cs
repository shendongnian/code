        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            _backgroundImageVisual  = ElementCompositionPreview.GetElementVisual(BackgroundImage);
            var graphicEffect   = new BlendEffect
            {
                Mode    = BlendEffectMode.Multiply,
                Background  = new ColorSourceEffect
                {
                    Color= Color.FromArgb(50, 0, 255, 0)
                },
                Foreground = new GaussianBlurEffect
                {
                    Source = new CompositionEffectSourceParameter("Backdrop"),
                    BlurAmount  = 20.0f,
                    BorderMode = EffectBorderMode.Hard
                }
            };
            
            var backdropBrush       = _compositor.CreateBackdropBrush();
            var blurEffectFactory   = _compositor.CreateEffectFactory(graphicEffect);
            _brush                  = blurEffectFactory.CreateBrush();
            _brush.SetSourceParameter("Backdrop", backdropBrush);
            _blurSprite          = _compositor.CreateSpriteVisual();
            _blurSprite.Brush    = _brush;
            ElementCompositionPreview.SetElementChildVisual(BackgroundImage, _blurSprite);
            
            _foregroundImageVisual  = ElementCompositionPreview.GetElementVisual(ClippedImage);
            _foregroundImageVisual.Clip = _compositor.CreateInsetClip(100, 100, 100, 100);
            
            SizeChanged += MainPage_SizeChanged;
            MainPage_SizeChanged(this, null);
        }
        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _blurSprite.Size    = new Vector2((float) BackgroundImage.ActualWidth, (float) BackgroundImage.ActualHeight);
            // change the clip values here to change the non-blurred region
            _foregroundImageVisual.Clip = _compositor.CreateInsetClip(100, 100, 100, 100);
        }
