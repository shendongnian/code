    [HttpPost]
    public ActionResult Delete(int? resumeId)
    {
        var r = _context.Resumes.Where(c => c.ResumeId == resumeId);
        _context.Resumes.RemoveRange(r);
        _context.SaveChanges();
        return RedirectToAction("ResumeCenter");
    }
