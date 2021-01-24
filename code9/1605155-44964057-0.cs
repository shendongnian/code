    @using Microsoft.AspNet.Identity
     
    <p>
    @Html.Raw("Hello " + User.Identity.GetUserName() + "!")
    </p>
