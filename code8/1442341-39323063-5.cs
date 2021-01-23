    public bool DoAction(IUploadAction action, UploadInformation information)
    {
        switch (information.Type)
        {
            case UploadTypes.AutoIncident:
                return action.Perform<AutoIncident>(information);
            case UploadTypes.Incident:
                return action.Perform<IncidentInjury>(information);
            case UploadTypes.Inspection:
                return action.Perform<Inspection>(information);
            case UploadTypes.OtherIncident:
                return action.Perform<OtherIncident>(information);
            default:
                return false;
        }
    }
