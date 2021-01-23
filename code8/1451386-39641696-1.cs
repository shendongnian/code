    if (WisState == State.Uninstalling)
    {
        if (e.PackageId.Equals("MSI1", StringComparison.Ordinal))
        {
            if (requestMSI1 == RequestState.Absent)
            {
                e.State = RequestState.Absent;
            }
            else
            {
                e.State = RequestState.None;
            }
        }
        else if (e.PackageId.Equals("MSI2", StringComparison.Ordinal))
        {
            if ("requestMSI" == RequestState.Absent)
            {
                e.State = RequestState.Absent;
            }
            else
            {
                e.State = RequestState.None;
            }
        }
    }
