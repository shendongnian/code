    public sealed partial class MainPage : Page
    {
        private CompositionEffectBrush  brush;
        private Compositor              compositor;
        public MainPage()
        {
            this.InitializeComponent();
            MainGrid.SizeChanged	+= OnMainGridSizeChanged;
            compositor		= ElementCompositionPreview.GetElementVisual(MainGrid).Compositor;
			// we create the effect. 
			// Notice the Source parameter definition. Here we tell the effect that the source will come from another element/object
            var blurEffect	= new GaussianBlurEffect
            {
                Name	    = "Blur",
                Source	    = new CompositionEffectSourceParameter("background"),
                BlurAmount	= 100f,
                BorderMode	= EffectBorderMode.Hard,
            };
			// we convert the effect to a brush that can be used to paint the visual layer
            var blurEffectFactory	= compositor.CreateEffectFactory(blurEffect);
            brush					= blurEffectFactory.CreateBrush();
			// We create a special brush to get the image output of the previous layer.
			// we are basically chaining the layers (xaml grid definition -> rendered bitmap of the grid -> blur effect -> screen)
            var destinationBrush	= compositor.CreateBackdropBrush();
            brush.SetSourceParameter("background", destinationBrush);
			// we create the visual sprite that will hold our generated bitmap (the blurred grid)
			// Visual Sprite are "raw" elements so there is no automatic layouting. You have to specify the size yourself
            var blurSprite			= compositor.CreateSpriteVisual();
            blurSprite.Size			= new Vector2((float) MainGrid.ActualWidth, (float) MainGrid.ActualHeight);
            blurSprite.Brush		= brush;
			// we add our sprite to the rendering pipeline
            ElementCompositionPreview.SetElementChildVisual(MainGrid, blurSprite);
        }
        private void OnMainGridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SpriteVisual blurVisual = (SpriteVisual) ElementCompositionPreview.GetElementChildVisual(MainGrid);
            if (blurVisual != null)
            {
                blurVisual.Size = e.NewSize.ToVector2();
            }
        }
    }
