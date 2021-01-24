    private async Task StartProcessing() {
        try {
            await Task.Delay(5000, _cancellationTokenSource.Token);
        } catch (TaskCanceledException e) {
            Debug.WriteLine($"Expected: {e.Message}");
        }
        Status = "Done!";
    }
