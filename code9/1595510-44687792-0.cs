    public static readonly DependencyProperty InstructionButtonContentProperty = DependencyProperty.Register(
        "InstructionButtonContent", typeof(FrameworkElement), typeof(InstructionBoxControl), new PropertyMetadata(default(FrameworkElement)));
    public FrameworkElement InstructionButtonContent
    {
        get { return (FrameworkElement) GetValue(InstructionButtonContentProperty); }
        set { SetValue(InstructionButtonContentProperty, value); }
    }
    public event RoutedEventHandler InstructionButtonClicked;
    public InstructionBoxControl()
    {
        InitializeComponent();
    }
    private void InstructionButtonClick(object sender, RoutedEventArgs e)
    {
        InstructionButtonClicked?.Invoke(sender, e);
    }
