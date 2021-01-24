    Employee existingEmployee = await _context.Employees.SingleOrDefaultAsync(
        m => m.FirstName == employee.FirstName && m.LastName == employee.LastName);
    if (existingEmployee != null)
    {
        // The employee already exists.
        // Do whatever you need to do - This is just an example.
        ModelState.AddModelError(string.Empty, "This employee already exists.");
        employee.Departments = _context.Departments.ToList();
        employee.Appointments = _context.Appointments.ToList();
        return View(employee);
    }
    // Your existing code for creating a new employee.
