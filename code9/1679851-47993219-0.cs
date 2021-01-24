    public List<Storage.FiducialMarkers> FinalMarkers
        {
            get {
                lock (mLock) {
                    return finalMarkers;
                }
            }
            set
            {
                lock (mLock)
                {
                    finalMarkers = value;
                }
            }
        }
