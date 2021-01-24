        private void ClearForm_OnClicked(object sender, EventArgs e)
        {
            BindingContext = new ViewModel();
            _viewModel = (ViewModel)BindingContext;
        }
