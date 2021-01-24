    public IActionResult ShowImage(int id)
    {
        var task = _context.Task.SingleOrDefault(m => m.ID == id);
        return File(task.Image, "image/jpeg");    //TODO: Set Content-Type appropriately
    }
