    private async Task UploadAsync(Object data)
    {
      await Task.Run(() =>
      {
        using (var factory = new DataRepositoryFactoryObject<IAllCommandRepository>(DataRepositoryFactory))
        {
          factory.Repository.UploadData(data);
        }
      });
    }
    private async void Upload(Object data)
    {
      await UploadAsync(data);
    }
