    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var authorized = ValidateStudentDeletion(User, studentId: id);
        if (authorized)
        {
            // delete student
            ...
            return RedirectToAction("Index");
        }
    }
