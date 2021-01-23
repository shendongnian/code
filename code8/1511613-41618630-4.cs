    class GridButton
    {
        public string Text { get; set; }
        public Brush Background { get; set; }
        public ICommand OnLeftClick { get; set; }
        public ICommand OnRightClick { get; set; }
    }
