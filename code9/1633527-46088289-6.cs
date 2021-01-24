    public ActionResult Delete(int resumeId)
    {
        var r = _context
            .Resumes
            .Where(c => c.ResumeId == resumeId).SingleOrDefault();
        if (r == null)
        {
            return RedirectToAction("ErrorPage");
        }
        else
        {
            _context.Resumes.Remove(r);
            _context.SaveChanges();
            return RedirectToAction("ResumeCenter");
        }
    }
