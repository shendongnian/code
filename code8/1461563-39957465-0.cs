    private async Task UploadAsync(Object data)
    {
        return Task.Run(() => {
               using (var factory = new DataRepositoryFactoryObject<IAllCommandRepository>(DataRepositoryFactory))
               {
                   factory.Repository.UploadData(data);
               }
        });
    }
