    [HttpGet]
    public JsonResult GetExistingJobTitles()
    {
    var foundData = _targetGroupsRepo.GetJobTitles();
    var returnObj = foundData.Select(x => new
    {
    value = x.Id,
    text = x.Name
    }).ToList();
    return Json(returnObj ,JsonRequestBehavior.AllowGet);
    }
