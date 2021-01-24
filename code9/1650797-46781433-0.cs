    @* View *@
    @{
        Model.ParseIds = Model.Id + "/" + Model.Contact.Id;
    }
    // Controller
    var model = new EmailModel();
    // assign Id & Contact.Id here
    model.ParseIds = model.Id + "/" + model.Contact.Id;
    return PartialView("_EmailAdd", model);
