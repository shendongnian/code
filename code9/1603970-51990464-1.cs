        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] ProfileUpdateModel profileUpdateModel)
        {
            //Do some stuff here...
            return  RedirectToAction("/", "HomeController");
        }
