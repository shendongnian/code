    public IActionResult DistanceOption(int id)
    {
        var model = new DistanceViewModel();
        model.EnumDistanceType = DistanceType.FiveMiles;
        return View(model);
    }
