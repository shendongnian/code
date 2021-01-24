    class Data{
        public string SelectedColor { get; set; }
        public Color FrontColor() {
            return System.Drawing.ColorTranslator.FromHtml(SelectedColor);
        }
    }
