    private void ShowDetail()
    {
      if (SelectedItem?.Id != null)
      {
        detailViewModel.Item = NotifyTask.Create(storage.GetDetailItemAsync(SelectedItem.Id);
      }
      else
      {
        detailViewModel.Item = null;
      }
    }
