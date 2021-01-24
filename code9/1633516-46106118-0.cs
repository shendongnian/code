    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int resumeId)
    {
        ... // check if the user has permission to delete the Resume with this id
        var r = _context.Resumes.Where(c => c.ResumeId == resumeId).SingleOrDefault();
        if (r != null)
        {
            _context.Resumes.Remove(r);
            _context.SaveChanges();
        }
        return RedirectToAction("ResumeCenter");
    }
