    class FadePanel : Panel
    {
        DrawPanel Layer = new DrawPanel();
        Bitmap image = null;
        float alpha = 0;
        float delta = 1;
        Timer timer = new Timer() { Interval = 25 };
        public bool FadeToParent { get; set; }
        public Color FadeColor { get; set; }
        public bool StaticContent { get; set; }
        public bool Hidden { get; private set; }
        public FadePanel()
        {  
            DoubleBuffered = true;
            Layer.Size = Size.Empty;
            Layer.Parent = this;
            Layer.BackColor = Color.Transparent;
            Layer.Paint += Layer_Paint;
            BackColor = Color.DodgerBlue;
            FadeToParent = false;
            Color FadeColor  = BackColor;
            Hidden = false;
            StaticContent = true;
            Layer.BackgroundImageLayout = ImageLayout.None;
            timer.Tick += timer_Tick;
        }
        void Layer_Paint(object sender, PaintEventArgs e)
        {
            if (alpha >= 0 && alpha <= 255)
            {
                using (SolidBrush brush = 
                   new SolidBrush(Color.FromArgb((int)alpha, FadeColor)))
                    e.Graphics.FillRectangle(brush, Layer.ClientRectangle);
            }
        }
        public void CaptureLayer()
        {
            if (image == null) image = new Bitmap(ClientSize.Width, ClientSize.Height);
            DrawToBitmap(image, ClientRectangle);
            Layer.BackgroundImage = image;
        }
        public void FadeOut(int ms)
        {
            alpha = 0;
            delta = 256f / ms * timer.Interval;
            Fade(delta);
        }
        public void FadeIn(int ms)
        {
            alpha = 255;
            delta = -256f / ms * timer.Interval;
            Fade(delta);
        }
        void Fade(float delta)
        {
            if (image == null || !StaticContent) CaptureLayer();
            BringToFront();
            FadeColor = FadeToParent ? Parent.BackColor : BackColor;
            Layer.BringToFront();
            Layer.Size = ClientSize;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            alpha += delta;
            if (alpha >= 255 || alpha <= 0)
            {
                alpha = delta > 0 ? 255 : 0;
                timer.Stop();
                if (delta < 0) BringToFront(); else SendToBack();
                Hidden = delta > 0;
                Layer.Size = delta > 0 ? ClientSize : Size.Empty;
            }
            Layer.Invalidate();
        }
    }
