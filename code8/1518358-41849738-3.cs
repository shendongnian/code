        public MainWindowViewModel()
        {
            StartCpuCommand = new RelayCommand(StartCpuMethod);
            StopCpuCommand = new RelayCommand(StopCpuMethod);
            SetupChartModel();
            Action<float, DateTime> dataPointSetter = new Action<float, DateTime>((v, d) => SetDataPoint(v, d));
            ActorSystemReference.CreateActorSystem(dataPointSetter);
        }
        private void SetDataPoint(float value, DateTime date)
        {
            CurrentValue = value;
            UpdateLineSeries(value, date);
        }
