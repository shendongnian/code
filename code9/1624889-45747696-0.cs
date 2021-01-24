    public IActionResult Get(Guid id)
    {
        Student student = _svc.Get(id);
        if (student != null)
        {
            return student;
        }
        return NotFound();
    }
