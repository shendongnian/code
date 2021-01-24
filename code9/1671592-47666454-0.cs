        public static SenderBackupProvider GetInstance()
        {            
            if (oInstance == null)
            {
                oInstance = new SenderBackupProvider(CommFunction.GetLogNumber(CommonConst.APPID));
            }
            
            return oInstance;
        }
