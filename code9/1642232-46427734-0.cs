    public ActionResult Index()
    {
        DataComponents dcomponents = new Models.DataComponents();
        //Getting Data From Database to Dictionary 
        dcomponents.clientName = getdata.Clients();
        dcomponents.schemaName = getdata.Schemas();
        return View(dcomponents);
    }
    [HttpPost]
    public ActionResult Change(DataComponents dcomponents)
    {
        //Select data on behalf of Client ID
        dcomponents.clientName = getdata.Clients();
        dcomponents.schemaName = getdata.Schemas(dcomponents.selectedClient);            
        return View("Index",dcomponents);
    }
    @using (Html.BeginForm("Change", "Home", FormMethod.Post))
    {
        <td>
            @Html.DropDownListFor(m => m.selectedClient,new SelectList(Model.clientName,"key","Value",Model.selectedClient), "Select Client", new { "this.form.submit();" })
        </td>
        <td>
            @Html.DropDownListFor(m => m.selectedSchema, new SelectList(Model.schemaName, "key", "Value", Model.selectedClient), "Select Schema", new { onchange = "this.form.submit();" }))
        </td>
    }
