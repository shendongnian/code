    @using WhatsUp.Models;
    @model List<Contact>
    
    @{
     ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    <ul>
    @foreach (Contact contact in Model)
    {
    <li>@Html.ActionLink(contact.name + "," + contact.phoneNumber, "Details", new { id = contact.id })</li>
    }
    </ul>
