    if (IsErrorWait == true)
    {
        aTimer.Interval = DefaultTick;
        IsErrorWait = false;
    }
    if (statusCode >= 500 && statusCode <= 504)
    {
        IsErrorWait = true;
        aTimer.Interval = WaitTick;
        return;
    }
    else
    {
        // This will post the migration status for anything EXCEPT a  server failure
        PostMigrationStatus(DocEntry, JobSuccess, jobID);
    }
