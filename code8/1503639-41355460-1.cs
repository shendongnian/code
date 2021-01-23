    CancellationTokenSource TextBoxCancellationTokenSource;
    async void TextBox_TextChanged()
    {
        string requestArg = TextBox.Text;
        if (TextBoxCancellationTokenSource != null)
        {
            // Cancel previous request.
            TextBoxCancellationTokenSource.Cancel();
        }
        TextBoxCancellationTokenSource = new CancellationTokenSource();
        CancellationToken cancellationToken = TextBoxCancellationTokenSource.Token;
        try
        {
            // Optional: a bit of throttling reducing the number
            // of server requests if the user is typing quickly.
            await Task.Delay(100, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested(); // Must be checked after every await.
            var response = await Task.Run(() => GetResponse(requestArg), cancellationToken);
            cancellationToken.ThrowIfCancellationRequested(); // Must be checked after every await.
            ProcessResponse(response);
        }
        catch (OperationCanceledException)
        {
            // Expected.
        }
    }
