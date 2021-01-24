      public ActionResult Insert(AddStudentViewModel st)
      {
          _context.stdnts.Add(st.stdntss );
          _context.SaveChanges();
          return RedirectToAction("Index","Students");
      }
