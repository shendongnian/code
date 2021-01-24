        [HttpGet("GetMachines")]
        public IActionResult GetMachines()
        {
            try
            {
                var results = _repository.GetAllMachineTypes();
    
                return Ok(Mapper.Map<IEnumerable<MachineTypeViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Machine types: {ex}");
                return BadRequest("Error Occurred");
            }
        }
