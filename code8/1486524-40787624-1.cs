    public class ListingConditionTableSync : BaseSyncClass<SyncResultCondition> {
        public ListingConditionTableSync(ISyncData syncData) : base(syncData) {
        }
        public override string UpdateRecordFromTable(SyncResultCondition sync) {
            throw new NotImplementedException();
        }
        public override string UpdateRecordFromTableNoSyncId(List<SyncResultCondition> sync) {
            throw new NotImplementedException();
        }
    }
