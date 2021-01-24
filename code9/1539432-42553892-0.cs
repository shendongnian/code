    @using (Html.BeginForm("Next", "Home", FormMethod.Post))
    { 
        @Html.HiddenFor(a=>a.CurrentIndex)
        <input type="submit"  class="buttonRightLeft"/>
    }
    @using (Html.BeginForm("Previous", "Home", FormMethod.Post))
    { 
        @Html.HiddenFor(a=>a.CurrentIndex)
        <input type="submit"  class="buttonLeftRight"/>
    }
    public ActionResult Next(int CurrentIndex)
    {
        // Get the NEXT image and return as model
        model = MyModel;
        return View("Searcher",model);
    }
    public ActionResult Previous(int CurrentIndex)
    {
        // Get the PREVIOUS image and return as model
        model = MyModel;
        return View("Searcher",model);
    }
