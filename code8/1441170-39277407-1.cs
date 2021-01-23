        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MyModel model)
        {
            await _modelRepository.Save(model);
            return CreatedAtRoute("GetModel", new {id = model.Id}, model);
        }
