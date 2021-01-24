    class YouTubeSlider : Slider
    {
        private Thumb _thumb;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _thumb = (Thumb)GetTemplateChild("Thumb");
            _thumb.Opacity = 0;
        }
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            _thumb.Opacity = 1;
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            _thumb.Opacity = 0;
        }
    }
