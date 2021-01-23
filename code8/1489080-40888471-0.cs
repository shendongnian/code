    private async Task SimpleMessageDialog(string Message, string Title)
    {
        MessageDialog dialog = new MessageDialog(Message, Title);
        dialog.CancelCommandIndex = 1;
        await dialog.ShowAsync();
    }
