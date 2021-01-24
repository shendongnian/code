    public int SelectedRep { get { return _ItemIsSelected;  }
        set
        {
            _dataStorage.CalculateRepRange = value;
            _ItemIsSelected = value;
            OnPropertyChanged(nameof(RepMaxCalcDataStorage));
        }
    }
