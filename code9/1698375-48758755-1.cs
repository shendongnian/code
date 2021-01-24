    public async void OnButtonClick()
    { 
        try {
            DateTime proposedDate = ...;
            await SetDateIfUserConfirmsAsync( proposedDate)
        } catch (Exception e) {
            // display or log the exception
        }
     }
 
