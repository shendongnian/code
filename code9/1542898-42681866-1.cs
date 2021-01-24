    set
    {
      _isSelected = value;
      if (value) { viewModel.SelectedFields.Add(this); }
      else { viewModel.SelectedFields.Remove(this); }
      NotifyPropertyChange();
    }
