     [Route("api/upload/{id}")]
        [HttpPost]
        public async Task<IActionResult> Post(string id)
        {
            var filePath = @"D:\" + id; //+ Guid.NewGuid() + ".png";
            if (Request.HasFormContentType)
            {
                var form = Request.Form;
                foreach (var formFile in form.Files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            return Ok(new { Path = filePath });
        }
