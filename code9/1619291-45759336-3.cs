    public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new MainViewModel();
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                var plotView = (PlotView) this.FindName("PlotView");
    
                plotView.LayoutUpdated += OnLayoutUpdated;
            }
    
            private void OnLayoutUpdated(object sender, EventArgs e)
            {
                var plotView = (PlotView) this.FindName("PlotView") ;
    
                if (plotView.Model != null)
                {
                    var widthAdjustment = plotView.Model.PlotArea.Width - plotView.Model.PlotArea.Height;
    
                    plotView.Width = plotView.ActualWidth - widthAdjustment;
                }
            }
        }
