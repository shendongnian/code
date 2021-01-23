        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
             using (var unitOfWork = new UnitOfWork(_db))
             {
                 var r = unitOfWork.Resources.Get(id);
                 if (r == null)
                 {
                    return NotFound();
                 }
                 return Ok(ConvertResourceModel(r));
            }
        }
