    public CustomSlider()
    {
        InitializeComponent();
    }
    public override void OnApplyTemplate()
    {
        Thumb thumb0 = (CMiXSlider.Template.FindName("PART_Track", CMiXSlider) as Track).Thumb;
        thumb0.MouseEnter += new MouseEventHandler(thumb_MouseEnter);
    }
