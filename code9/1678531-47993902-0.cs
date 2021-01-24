        [Export("layerClass")]
        public static Class LayerClass()
        {
            return new Class(typeof(CATiledLayer));
        }
        public PlanMarkingView(nfloat scale)
        {
            tiledLayer = Layer as CATiledLayer;
            tiledLayer.LevelsOfDetail = 8;
            tiledLayer.LevelsOfDetailBias = 3;
            tiledLayer.TileSize = new CGSize(1024f, 1024f);
            tiledLayer.BackgroundColor = UIColor.Red.CGColor;
            tiledLayer.BorderWidth = 0;
        }
        [Export("drawLayer:inContext:")]
        public override void DrawLayer(CALayer layer, CGContext context)
        {
            context.SetFillColor(1f, 1f, 1f, 1f);
            context.FillRect(Bounds);
            context.SaveState();
            context.TranslateCTM(0f, Bounds.Height);
            context.ScaleCTM(1f, -1f);
            context.DrawImage(new CGRect(0, 0, Image.Width, Image.Height), Image);
            if (MarkEnabled && initialPoint != null && latestPoint != null)
            {
            }
            context.RestoreState();
        }
