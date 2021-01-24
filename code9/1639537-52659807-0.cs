    using System;
    using SharpDX;
    using SharpDX.Direct2D1;
    using SharpDX.DirectWrite;
    using SharpDX.Samples;
    using TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode;
    namespace TextRenderingApp
    {
      public class Program : Direct2D1DemoApp
      {        
        public TextFormat TextFormat { get; private set; }
        public TextLayout TextLayout { get; private set; }
        protected override void Initialize(DemoConfiguration demoConfiguration)
        {
            base.Initialize(demoConfiguration);
            // Initialize a TextFormat
            TextFormat = new TextFormat(FactoryDWrite, "Calibri", 128) {TextAlignment = TextAlignment.Center, ParagraphAlignment = ParagraphAlignment.Center};
            RenderTarget2D.TextAntialiasMode = TextAntialiasMode.Cleartype;
            // Initialize a TextLayout
            TextLayout = new TextLayout(FactoryDWrite, "SharpDX D2D1 - DWrite", TextFormat, demoConfiguration.Width, demoConfiguration.Height);
        }
        protected override void Draw(DemoTime time)
        {
            base.Draw(time);
            // Draw the TextLayout
            RenderTarget2D.DrawTextLayout(new Vector2(0,0), TextLayout, SceneColorBrush, DrawTextOptions.None );
        }
        [STAThread]
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run(new DemoConfiguration("SharpDX DirectWrite Text Rendering Demo"));
        }
      }
    }
