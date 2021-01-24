    [HttpGet("{id}", Name = "GetTodo")]
    public IActionResult GetById(long id)
    {
        var item = _todoRepository.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return new ObjectResult(item);
    }
