        [HttpGet]
        public IActionResult GetDices([Required, Range(1, 6)]int number)
        {
            if (ModelState.IsValid)
            {
                return Ok(_diceRepo.GetDices(number));
            }
            return BadRequest("Something went wrong");
        }
