    public class HoursDateDialogViewModel : MvxViewModel<EstimateHours>
    {
        private readonly IMvxNavigationService _navigationService;
        public HoursDateDialogViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            CloseCommand = new MvxAsyncCommand(async () => await _navigationService.Close(this));
        }
        public override System.Threading.Tasks.Task Initialize()
        {
            return base.Initialize();
        }
        public override void Prepare(EstimateHours parm)
        {
            base.Prepare();
            Hours = parm;
        }
        public IMvxAsyncCommand CloseCommand { get; private set; }
        private EstimateHours _Hours;
        public EstimateHours Hours
        {
            get
            {
                return _Hours;
                    }
            set
            {
                _Hours = value;
                RaisePropertyChanged(() => Hours);
                RaisePropertyChanged(() => WorkDate);
            }
        }
        public DateTime WorkDate
        {
            get
            {
                return Hours.StartTime ?? DateTime.Today;
            }
            set
            {
                DateTime s = Hours.StartTime ?? DateTime.Today;
                DateTime d = new DateTime(value.Year, value.Month, value.Day, s.Hour, s.Minute, s.Second);
                Hours.StartTime = d;
                DateTime e = Hours.EndTime ?? DateTime.Today;
                d = new DateTime(value.Year, value.Month, value.Day, e.Hour, e.Minute, e.Second);
                Hours.EndTime = d;
                RaisePropertyChanged(() => WorkDate);
            }
        }
    }
