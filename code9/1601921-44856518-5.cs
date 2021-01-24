    class MainViewModel : NotifyPropertyChangedBase
    {
        public ObservableCollection<ButtonViewModel> Buttons { get; } = new ObservableCollection<ButtonViewModel>();
        public ICommand ResetCommand { get; }
        public MainViewModel()
        {
            ResetCommand = new DelegateCommand(_Reset);
            for (int i = 0; i < Settings.Default.Colors.Count; i++)
            {
                ButtonViewModel buttonModel = new ButtonViewModel(i) { Color = Settings.Default.Colors[i] };
                Buttons.Add(buttonModel);
                buttonModel.PropertyChanged += (s, e) =>
                {
                    ButtonViewModel model = (ButtonViewModel)s;
                    Settings.Default.Colors[model.ButtonIndex] = model.Color;
                    Settings.Default.Save();
                };
            }
        }
        private void _Reset()
        {
            foreach (ButtonViewModel model in Buttons)
            {
                model.Reset();
            }
        }
    }
