        public delegate void ChangeEditingStateDelegate();
        public void Execute(object parameter)
        {
            // Actions defered through Dispatcher because:
            // - The actions invoke triggers which change focus
            // - User may Tab out of a field invoking this command.
            // - If so, the UI thread needs to finish default Tab focus updates before these further actions occur.
            System.Windows.Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ChangeEditingStateDelegate(this.ChangeEditingState));
        }
        private void ChangeEditingState()
        {
            // The current editing state determines what this command button should be doing
            switch (this.viewModel.EditingState)
            {
                case EditingState.Initial:
                    // Search for airframes
                    this.SearchForAirframes();
                    break;
                case EditingState.Search:
                    // Save edits
                    this.SaveUpdates();
                    break;
                case EditingState.New:
                    // Save new airframe
                    this.SaveUpdates();
                    break;
                default:
                    throw new ArgumentException("Unknown editing state");
            }
        }
