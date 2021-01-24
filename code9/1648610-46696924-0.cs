    public IActionResult Profile(string id)
    {
        Guid guid = Guid.Parse(id);
        var Profile = unitOfWork.TechnicianRepository.GetByGuidId(guid);
        return View(Profile);
    }
