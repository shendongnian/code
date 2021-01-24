	private const int MaxXToPopup = 300;
    private Window _popup;
    
    public MainWindow()
    {
        InitializeComponent();
    }
    
    protected override void OnRenderSizeChanged( SizeChangedInfo sizeInfo )
    {
        if ( ShouldDisplayInPopup() )
        {
            DetachPartTwo();
            OpenPopup();
        }
        else if ( ShouldDisplayInGrid() )
        {
            ClosePopup();
            ShowPartTwo();
        }
    
        base.OnRenderSizeChanged( sizeInfo );
    }
    
    private void ClosePopup()
    {
        _popup.Content = null;
        _popup.Close();
        _popup = null;
    }
    
    private void OpenPopup()
    {
        _popup = new Window {Content = PartTwo};
        _popup.Show();
    }
    
    private void ShowPartTwo()
    {
        PartTwoContainer.Children.Add( PartTwo );
    }
    
    private void DetachPartTwo()
    {
        PartTwoContainer.Children.Remove( PartTwo );
    }
    
    private bool ShouldDisplayInGrid()
    {
        return _popup != null && RenderSize.Width > MaxXToPopup;
    }
    
    private bool ShouldDisplayInPopup()
    {
        return _popup == null && RenderSize.Width < MaxXToPopup;
    }
