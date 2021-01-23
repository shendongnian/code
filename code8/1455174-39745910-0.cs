    public virtual void OnBeforeSavingRecord(object sender, EntitySavingEventArgs<T> e)
    {
        System.EventHandler<EntitySavingEventArgs<T>> handler = BeforeSavingRecord;
        if (handler != null)
        {   // fire at will
            handler(this, e);
        }
    }
