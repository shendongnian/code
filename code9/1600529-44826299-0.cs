    public void MyCacheItemRemovedCallbackMethod(string key, object value, CacheItemRemovedReason reason)
            {   
                this.Invalidate();
                cacheRemoveReason = reason;
    
                switch (cacheRemoveReason.ToString())
                {
                    case dependencyChanged:
                        {
                            Log.Debug("I am logging my reason with datetime modified");
                            break;
                        }
                    case expired:
                        {
                           Log.Debug("I am logging my reason with datetime modified");
                            break;
                        }
                    case removed:
                        {   
                            Log.Debug("I am logging my reason with datetime modified");
                           break;
                        }
                    default:
                            Log.Debug("I am logging my reason with datetime modified");
                            break;
                }
            }
