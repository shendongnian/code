    CancellationTokenSource TextBoxCancellationTokenSource;
    async void TextBox_TextChanged()
    {
        if (TextBoxCancellationTokenSource != null)
        {
            // Cancel previous request.
            TextBoxCancellationTokenSource.Cancel();
        }
        TextBoxCancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = TextBoxCancellationTokenSource.Token;
        try
        {
            // Optional: a bit of throttling reducing the number of server requests.
            await Task.Delay(100, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested(); // Must be checked after every await.
            var response = await Task.Run(() => GetResponse(), cancellationToken);
            cancellationToken.ThrowIfCancellationRequested(); // Must be checked after every await.
            ProcessResponse(response);
        }
        catch (OperationCanceledException)
        {
            // Expected.
        }
    }
