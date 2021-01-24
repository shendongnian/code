    public void StartMotionUpdates (Action<ActivityType> handler)
    		{
    			motionActivityMgr.StartActivityUpdates (NSOperationQueue.MainQueue, ((activity) => {
    				handler (ActivityDataManager.ActivityToType (activity));
    			}));
    		}
