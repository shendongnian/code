    private Dictionary<string, BoneKeyFrameCollection> dict =
                new Dictionary<string, BoneKeyFrameCollection>();
    private ReaderWriterLockSlim dictLock = new ReaderWriterLockSlim();
    
    public BoneKeyFrameCollection this[string boneName]
    {           
        get 
        { 
            try
            {
                dictLock.EnterReadLock();
                return dict[boneName]; 
            }
            finally
            {
                dictLock.ExitReadLock();
            }
        }
    }
    
     public void UpdateBone(string boneName, BoneKeyFrameCollection col)
     {  
        try
        {
            dictLock.EnterWriteLock();
            dict[boneName] = col; 
        }
        finally
        {
            dictLock.ExitWriteLock();
        }
     }
