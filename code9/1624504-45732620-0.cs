    public ViewResult Details(int id = 0)
    {
        //vm.ImageToShow = Convert.ToBase64String(model.Picture)
        vm.ID = id;
        return View(vm);
    }
    public FileResult Image(int id = 0)
    {
        ..
        return File(model.Picture,"image/jpeg");
    }
    @Html.Raw("<img src=\"image?id=" + Model.ID + "\" 
    onclick='javascript: window.open(\"image?id=," + Model.ID + "\")'/>")
