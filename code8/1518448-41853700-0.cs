    public ICommand UpdateDescription
    {
        get
        {
            return new RelayCommand<Part>(UpdateDescriptionExecute, CanUpdateDescriptionExecute);
        }
    }
    private void UpdateDescriptionExecute(Part part)
    {
        MessageBox.Show(part.PartCode);
    }
    private bool CanUpdateDescriptionExecute(Part part)
    {
        if (count >= 2)
            return false;
        else
            return true;
    }
