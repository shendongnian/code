    public IActionResult Get(Guid id)
    {
        Student student = _svc.Get(id);
        if (student != null)
        {
            return Ok(student);
        }
        return NotFound();
    }
