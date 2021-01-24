@if (User.IsInRole("Student"))
        {
            <a asp-action="StudentDashboard" asp-controller="Home">Dashboard</a>
        }
        else
        if (User.IsInRole("College"))
        {
            <a asp-action="CollegeDashboard" asp-controller="Home">Dashboard</a>
        }
        else
        if (User.IsInRole("Manager"))
        {
            <a asp-action="AdminDashboard" asp-controller="Home">Dashboard</a>
        }
        else
        if (User.IsInRole("Admin"))
        {
            <a asp-action="AdminDashboard" asp-controller="Home">Dashboard</a>
        }```
