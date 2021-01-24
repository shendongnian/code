    public async Task<bool> TryCatchExecution(Func<Task> action, string successMessage = null)
    {
        try
        {
            await action();
            if (!string.IsNullOrEmpty(successMessage))
                DialogService.ShowMessage(successMessage, Resources.Success);
            return true;
        }
        catch (LogException ex)
        {
            DialogService.ShowError(ex.Error.LogMessage, Resources.Error, Resources.OK, null);
        }
        catch (Exception ex)
        {
            DialogService.ShowError(ex.Message, Resources.Error, Resources.OK, null);
        }
        return false;
    }
