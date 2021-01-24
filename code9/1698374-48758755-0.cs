    public DateTime Date { get; private set; }
    
    public Task SetDateIfUserConfirmsAsync( DateTime proposedDate) 
    { 
         var confirmConfig = new ConfirmConfig() {
             Message = "Are you sure ?",
             OnConfirm = b => { if (b) { this.Date = proposedDate; } }
         }
         await Mvx.Resolve<IUserDialogs>().ConfirmAsync( confirmConfig);
    }
