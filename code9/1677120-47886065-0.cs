        Student student = db.Students.Find(newid.UserID);
        if (student == null)
        {
            return HttpNotFound();
        }
        TestViewModel tvm = new TestViewModel()
        {
            UserID =student.Id,
            PhoneNumber = student.PhoneNumber,
            Address= student.Address
        };
        return View(tvm);
     }
