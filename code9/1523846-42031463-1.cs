    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
        Student s = studentRepository.GetStudentByID(id);
    
        if (s.PaymentDue > 0)
        {
            ViewBag.ErrorMessage = "Student has overdue payment. Need to CLEAR payment before deletion!";
            // Assuming that you are using Student object to populate your delete view
    		return View(s);
        }
    	
        try
        {
            Student student = studentRepository.GetStudentByID(id);
            studentRepository.DeleteStudent(id);
            studentRepository.Save();
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        }
        return RedirectToAction("Index");
    }
