    Task<T1> referralTask = null;
    Task<T2> assessmentTask = null;
    Task<T3> summaryTask = null;
    if (client.ReferralDocument != null)
      referralTask = TransmitDocumentAsync(client.ReferralDocument);
    if (client.Assessment != null)
      assessmentTask = TransmitDocumentAsync(client.Assessment);
    if (cilent.Summary != null)
      summaryTask = TransmitDocumentAsync(client.Summary);
    if (referralTask != null)
    {
      var referralResponse = await referralTask;
      ...
    }
    if (assessmentTask != null)
    {
      var assessmentResponse = await assessmentTask;
      ...
    }
    if (summaryTask != null)
    {
      var summaryResponse = await summaryTask;
      ...
    }
