    @using WhatsUp.Controllers
    @using WhatsUp.Models
    @model Contact
    
    @{
        ViewBag.Title = "Details";
    }
    
    <h2>Contact Details</h2>
    <p>@Model.name</p>
