    public IActivity GetActivity(ActivityType activityType)
    {
        return this._activities
          .First(m => m.Metadata["activity"].Equals(activityType))
          .Value // The value from the Meta<T> object is a Lazy<T>
          .Value; // This resolves the T from Lazy<T>
    }
