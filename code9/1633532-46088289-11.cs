    public ActionResult Delete(int resumeId)
    {
        var r = _context
            .Resumes
            .Where(c => c.ResumeId == resumeId).Single();  //Error will bounce up to Application_Error or other global handler
        _context.Resumes.Remove(r);
        _context.SaveChanges();
        return RedirectToAction("ResumeCenter");
    }
