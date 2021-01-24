    public void CalulateNextMaintenance()
    {
        if (LastMaintenance == null)
        {
            NextMaintenance = null;
            return;
        }
        switch (Scale)
        {
            case MaintenanceScale.Minute:
                NextMaintenance = LastMaintenance.Value.AddHours(Span);
                break;
            case MaintenanceScale.Hour:
                NextMaintenance = LastMaintenance.Value.AddHours(Span * 2);
                break;
            case MaintenanceScale.Day:
                NextMaintenance = LastMaintenance.Value.AddDays(Span);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
