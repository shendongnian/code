    public abstract class BaseSyncClass<T> : INotifyPropertyChanged where T : SyncResultBase {
        private readonly ISyncData _syncData;
	
        public BaseSyncClass(ISyncData syncData) {
            _syncData = syncData;
        }
        public abstract string UpdateRecordFromTable(T sync);
        public abstract string UpdateRecordFromTableNoSyncId(List<T> sync);
        public void UpdateFromServer(List<T> result) {
            foreach (T sync in result) {
                UpdateRecordFromTable(sync);
            }
        }
    }
