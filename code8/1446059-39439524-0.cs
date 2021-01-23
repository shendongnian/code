    public static class RealAppCoreHelper
    {
        private static RealAppCoreObject m_GlobalAppInstance = null;
        public static RealAppCoreObject GetGlobalMainInstance()
        {
            // return the one and only instance of our main app
            if (m_GlobalAppInstance == null)
            {
                m_GlobalAppInstance = new RealAppCoreObject();
            }
            return m_GlobalAppInstance;
        }
    }
