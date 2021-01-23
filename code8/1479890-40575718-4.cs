    [HttpGet]
        public ActionResult Create(string nomenclatureType)
        {
            if (nomenclatureType == null)
                return RedirectToAction("List", "Nomenclature");
            var viewModel= new CreateMomenClatureViewModel
    {
    Attributes = _repositoryNomenclatureType.Get(w => w.Name == nomenclatureType).NomenclatureAttributes.ToList()
    }
            
        return View(viewModel);
    }
