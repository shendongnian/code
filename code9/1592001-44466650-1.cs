    Mvx.Resolve<IUserDialogs>().Confirm(new ConfirmConfig
    {
        OnAction = b =>
        {
            if (b)
            {
                NotifyUpdated();
            }
        }
    });
