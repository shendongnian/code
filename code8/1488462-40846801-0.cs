    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (VM.HasChanges)
            {
                continuationCallback(false);
            }
            else
                continuationCallback(true);
        }
