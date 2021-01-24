     // GET api/messages/{id}
        [HttpGet("{id:long}", Name = "GetMessage")]
        public IActionResult GetById(long id)
        {
            var message = _repository.GetMessage(id);
            if (message == null)
            {
                return NotFound();
            }
            return new ObjectResult(message);
        }
