        public int SelectedPosition
        {
            get => _viewModel.CurrentRowIndex;
            set
            {
                int lastPos = _viewModel.CurrentRowIndex;
                _viewModel.CurrentRowIndex = value;
                NotifyItemChanged(lastPos);
                NotifyItemChanged(value);
            }
        }
