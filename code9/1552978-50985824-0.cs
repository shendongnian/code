    private PlotModel m_plotModel;
    public PlotModel plotModel
    {
        get { return m_plotModel; }
        set => SetAndRaisePropertyChanged(ref m_plotModel, value);
    }
    public UserControlOscilloViewModel()
    {
        var signalAxis = new CategoryAxis()
        {
            Position = AxisPosition.Left,
            Minimum = 0,
            MinimumMinorStep = 1,
            AbsoluteMinimum = 0,
            TicklineColor = OxyColors.Transparent,
        };
        var timeAxis = new LinearAxis()
        {
            Position = AxisPosition.Bottom,
            Minimum = 0,
            MinimumMajorStep = 1,
            AbsoluteMinimum = 0,
        };
    
        plotModel = new PlotModel();            
        plotModel.Axes.Add(signalAxis);
        plotModel.Axes.Add(timeAxis);
    }
