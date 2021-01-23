    public Guid? GetNextGuid()
    {
        lock (objectlock)
        {
            if (this.LastGuidHolder.HasValue)
            {
                this.LastGuidHolder = Increment(this.LastGuidHolder.Value);
            }
            else
            {
                this.LastGuidHolder = Increment(this.StartingGuid);
            }
            return this.LastGuidHolder;
        }
    }
