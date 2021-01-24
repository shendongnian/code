        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        private CompositionSurfaceBrush _maskSurfaceBrush;
        private readonly float _size = 512;
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PointerMoved += MainPage_PointerMoved;
            var compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            var canvasDevice = CanvasDevice.GetSharedDevice();
            var graphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(compositor, canvasDevice);
            var canvasBitmap = await CanvasBitmap.LoadAsync(canvasDevice, new Uri("ms-appx:///Assets/44578.jpg"));
            var sourceDrawingSurface = graphicsDevice.CreateDrawingSurface(new Size(_size, _size), DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);
            using (var ds = CanvasComposition.CreateDrawingSession(sourceDrawingSurface))
            {
                ds.Clear(Colors.Transparent);
                ds.DrawImage(canvasBitmap);
            }
            var sourceSurfaceBrush = compositor.CreateSurfaceBrush(sourceDrawingSurface);
            var maskRenderTarget = new CanvasRenderTarget(canvasDevice, _size, _size, 96);
            using (var ds = maskRenderTarget.CreateDrawingSession())
            {
                ds.Clear(Colors.Transparent);
                ds.FillCircle(_size / 2, _size / 2, _size / 8, Colors.Black);
            }
            var blur = new GaussianBlurEffect
            {
                BlurAmount = 16,
                Source = maskRenderTarget
            };
            var blurredMaskDrawingSurface = graphicsDevice.CreateDrawingSurface(new Size(_size, _size), DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);
            using (var ds = CanvasComposition.CreateDrawingSession(blurredMaskDrawingSurface))
            {
                ds.Clear(Colors.Transparent);
                ds.DrawImage(blur);
            }
            _maskSurfaceBrush = compositor.CreateSurfaceBrush(blurredMaskDrawingSurface);
            var composite = new CompositeEffect
            {
                Sources = { new CompositionEffectSourceParameter("source"), new CompositionEffectSourceParameter("mask") },
                Mode = CanvasComposite.DestinationAtop
            };
            var effectFactory = compositor.CreateEffectFactory(composite);
            var fxBrush = effectFactory.CreateBrush();
            fxBrush.SetSourceParameter("source", sourceSurfaceBrush);
            fxBrush.SetSourceParameter("mask", _maskSurfaceBrush);
            var sprite = compositor.CreateSpriteVisual();
            sprite.Size = new Vector2(_size, _size);
            sprite.Brush = fxBrush;
            ElementCompositionPreview.SetElementChildVisual(this, sprite);
        }
        private void MainPage_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var position = e.GetCurrentPoint(this).Position.ToVector2();
            _maskSurfaceBrush.Offset = position - new Vector2(_size / 2, _size / 2);
        }
