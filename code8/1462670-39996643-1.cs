    public class ClassToBeTested {
        private readonly AbstractFactory syncFactory;
        public ClassToBeTested (AbstractFactory factory) {
            this.syncFactory = factory
        }
        public void MethodTobeTested() {
            var syncService = syncFactory.GetSyncService(entityType);
            //...other code
        }
    
    }
