    public class AzureCloudSyncTable<TModel> where TModel : class
    {
        public static MobileServiceClient MobileService = new MobileServiceClient(
            "https://{your-mobile-app-name}.azurewebsites.net"
        );
        private IMobileServiceSyncTable<TModel> syncTable = MobileService.GetSyncTable<TModel>();
        #region Offline sync
        private async Task InitLocalStoreAsync()
        {
            if (!MobileService.SyncContext.IsInitialized)
            {
                var store = new MobileServiceSQLiteStore("localstore.db");
                store.DefineTable<TModel>();
                await MobileService.SyncContext.InitializeAsync(store);
            }
            await SyncAsync();
        }
        private async Task SyncAsync()
        {
            await PushAsync();
            await syncTable.PullAsync(typeof(TModel).Name, syncTable.CreateQuery());
        }
        private async Task PushAsync()
        {
            try
            {
                await MobileService.SyncContext.PushAsync();
            }
            catch (MobileServicePushFailedException ex)
            {
                if (ex.PushResult != null)
                {
                    foreach (var error in ex.PushResult.Errors)
                    {
                        await ResolveConflictAsync(error);
                    }
                }
            }
        }
        private async Task ResolveConflictAsync(MobileServiceTableOperationError error)
        {
            //var serverItem = error.Result.ToObject<TModel>();
            //var localItem = error.Item.ToObject<TModel>();
            //// Note that you need to implement the public override Equals(TModel item)
            //// method in the Model for this to work
            //if (serverItem.Equals(localItem))
            //{
            //    // Items are the same, so ignore the conflict
            //    await error.CancelAndDiscardItemAsync();
            //    return;
            //}
            //// Client Always Wins
            //localItem.Version = serverItem.Version;
            //await error.UpdateOperationAsync(JObject.FromObject(localItem));
            // Server Always Wins
            //await error.CancelAndDiscardItemAsync();
        }
        #endregion
        #region public methods
        public async Task<List<TModel>> GetAll()
        {
            await InitLocalStoreAsync();
            await SyncAsync();
            return await syncTable.ToListAsync();
        }
        public async Task Insert(List<TModel> items)
        {
            await InitLocalStoreAsync();
            await Task.WhenAll(items.Select(item => syncTable.InsertAsync(item)));
            await PushAsync();
        } 
        #endregion
    }
