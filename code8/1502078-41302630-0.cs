    @using ClassDeclarationsThsesis.Models
    @using Microsoft.AspNet.Identity
    @model List<Users>
    @{
    ViewBag.Title = "My Marks";
    }
    <div>
    <h4>Account information</h4>
    <hr/>
    @foreach(var student in Model) 
    {
    <dl class="dl-horizontal">
        <dt>Name</dt>
        <dd>@student.Name</dd>
        <dd></dd>
        <dt>Surname</dt>
        <dd>@student.surname</dd>
        <dt>@student.Email</dt>
        <dd>
            @HttpContext.Current.User.Identity.Name
        </dd>
    </dl>
    }
    </div>
