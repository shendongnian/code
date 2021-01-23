    public ActionResult getProjectsFromEbit(string modelData)
        {
            var systemOutputList = new List<EbitModel>();
            systemOutputList = JsonConvert.DeserializeAnonymousType(modelData, systemOutputList);
            return PartialView("_getProjects",systemOutputList);
        }
