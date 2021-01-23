    public bool StoreUpload(IUploadActions actions, UploadInformation information)
    {
        switch (information.Type)
        {
            case UploadTypes.AutoIncident:
                return actions.RemoveUpload<AutoIncident>(information);
            case UploadTypes.Incident:
                return actions.RemoveUpload<IncidentInjury>(information);
            case UploadTypes.Inspection:
                return actions.RemoveUpload<Inspection>(information);
            case UploadTypes.OtherIncident:
                return actions.RemoveUpload<OtherIncident>(information);
            default:
                return false;
        }
    }
