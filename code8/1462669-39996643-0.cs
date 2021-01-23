    public class ClassToBeTested {
    
        public void MethodTobeTested() {
            var syncService = new SyncFactory(_operatorRepository).GetSyncService(entityType);
            //...other code
        }
    
    }
