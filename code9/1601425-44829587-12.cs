    public class ApplicationViewModel
    {
        private EventAgregator _eventAggregator;
        ApplicationViewModel(EventAgregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            _eventAggregator.Subscribe('ChangeViewModelRequest', (EventArgs eventArgs) => ChangeViewModel(eventArgs.Parameter))
        }
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
    }
