    protected override void CancelDeletionForSoftDelete(EntityEntry entry)
    {
        if (IsSoftDeleteFilterEnabled)
        {
            base.CancelDeletionForSoftDelete(entry);
        }
    }
