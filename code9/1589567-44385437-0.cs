    private async void StartTbTNavigationSession()
    {
      using (var session = new ExtendedExecutionSession())
      {
        session.Reason = ExtendedExecutionReason.LocationTracking;
        session.Description = "Turn By Turn Navigation";
        session.Revoked += session_Revoked;
        var result = await session.RequestExtensionAsync();
        if (result == ExtendedExecutionResult.Denied
        {
          ShowUserWarning("Background location tracking not available");
        }
        // Do Navigation
        var completionTime = await DoNavigationSessionAsync(session);
      }
    }
