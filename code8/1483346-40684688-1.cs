    var responses = new List<Task>();
    if (client.ReferralDocument != null)
      responses.Add(TransmitDocumentAsync(client.ReferralDocument));
    if (client.Assessment != null)
      responses.Add(TransmitDocumentAsync(client.Assessment));
    if (cilent.Summary != null)
      responses.Add(TransmitDocumentAsync(client.Summary));
    await Task.WhenAll(responses);
