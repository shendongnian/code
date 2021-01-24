    public static class ServiceManager {
        // The variable holding the instance
        private static AbcService _abcService = null;
        // Access to the instance and single instance creator
        public static AbcService AbcServiceInstance {
            get {
                if (_abcService == null) {
                    // Create your Instance here
                    _abcService = new AbcService();
                }
                return _abcService;
            }
        }
    
        // The variable holding the instance
        private static XyzService _xyzService = null;
        // Access to the instance and single instance creator
        public static XyzService XyzServiceInstance {
            get {
                if (_xyzService == null) {
                    // Create your Instance here
                    _xyzService = new XyzService();
                }
                return _xyzService;
            }
        }
    }
