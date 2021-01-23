    @using ChameleonForms
    @using ChameleonForms.Component
    @using ChameleonForms.Enums
    @using ChameleonForms.Templates
    @using ChameleonForms.ModelBinders
    @model DirectInvoice.Models.Customers
    @{
    ViewBag.Title = "Create";
    }
    <div>
    @using (var f = Html.BeginChameleonForm())
    {
        @Html.AntiForgeryToken()
        using (var s = f.BeginSection("Add a new customer"))
        {
            @s.FieldFor(m => m.CompanyNumber)
            @*<button type="button" onclick="location.href='@Url.Action("GetCompanyInfo", "Customers", new { id = "Ask" })'" class="btn btn-default">Ask the web!</button>*@
            <button id="Ask" type="button" class="btn btn-default">Ask the web!</button>
            @s.FieldFor(m => m.Name)
            @s.FieldFor(m => m.CompanyRegistration)
            @s.FieldFor(m => m.Phone1).Placeholder("0XX X XXX XXX")
            @s.FieldFor(m => m.Fax).Placeholder("0XX X XXX XXX")
            @s.FieldFor(m => m.Email).Placeholder("name@email.com")
            @s.FieldFor(m => m.Address)
            @s.FieldFor(m => m.ZIP)
            @s.FieldFor(m => m.City)
            
        }
        using (var n = f.BeginNavigation())
        {
            @n.Submit("Save the new customer...")
        }
    }
    </div>
