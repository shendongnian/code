    public IAction SomeAction()
    {
         if (/* The request was bad */)
            return BadRequest();
        return Ok(/* The result when all is well */);
    }
