      @foreach (var c in Model.Cleaners)
     {
    c.ConfirmationChecker = 1;
    foreach (var p in c.TimeConfirmations)
    {
        if (condition)
        {
            c.ConfirmationChecker = 0;
        }
        
       
    }
    }
