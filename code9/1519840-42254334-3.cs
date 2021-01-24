    public void SendBreadcrumbs(string telemetry, string userID = null, bool isMyVI = true)
    {
        MyServiceAudit audit;
        Guid UserID;
        if (Guid.TryParse(userID, out UserID))
            audit = InsertAudit(UserID);
        else
            audit = InsertAudit(null);
        try
        {
            Models.Telemetry data = JsonConvert.DeserializeObject<Models.Telemetry>(Uri.UnescapeDataString(telemetry));
            Controllers.Telemetry.UpdateTelemetry(data, isMyVI);
        }
        catch (Exception ex)
        {
             MyServiceAuditDB.FailAudit(audit.ID, ex.Message + " " + ex.StackTrace);
        }
    }
