    [HttpPost]
            [Route("upload")]
            public async Task<IActionResult> Upload([FromForm] FileUploadViewModel model, [FromForm] string member_code)
            {
                var file = model.File;
                
                ...
            }
