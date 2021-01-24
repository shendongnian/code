    public ActionResult Switchb(string categoryNumber) {
        var viewModel = new MyViewModel { CategoryNubmer = categoryNumber };
        // additional processing, backend calls, formatting ....
        return PartialView(categoryNumber, viewModel);
    }
