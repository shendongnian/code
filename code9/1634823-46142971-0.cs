    [HttpPost]
    public IHttpActionResult CreateClass([FromBody] Classes classObj) {
        if (classObj == null) {
            return BadRequest("missing parameters.");
        }
        _context.Classes.Add(classObj);
        _context.SaveChanges();
        var newClassUrl = Url.Content("~/") + "/api/classes/" + classObj.Id.ToSTring();
        return Created(newClassUrl, classObj);
    }
