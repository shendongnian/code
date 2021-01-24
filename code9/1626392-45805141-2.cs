    @foreach (Reservation r in Model)
    {
        string alertClass = "";
        if (r.DateTo.AddDays(-1).Day <= DateTime.Now.Day)
        {
            alertClass = "danger";
        }
        else
        {
            alertClass = "";
        }
        
        //Rest of your original Razor
