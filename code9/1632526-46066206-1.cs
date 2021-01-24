        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatReg([FromRoute] long id)
        {
        
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }
                    var patReg = await _context.PatReg
                        .Where(m => m.FileId == id)
                        .ToListAsync();
        
                    var patpar = await _context.PatPar.Select(m => new PatParDto {
                        RecId = m.RecId,
                        FileId = m.FileId,
                        ParFileId = m.ParFileId,
                        SDate = m.SDate,
                        EDate = m.EDate,
                    }).ToListAsync();
                    for (int i = 0; i < patpar.Count; i++)
        
                    {
                        patpar[i].FullName = (from a in _context.PatReg
                        where (a.FileId == patpar[i].ParFileId)
                                              select new { a.fullname }
                                              ).Single().fullname;                                      
        
                    }
        
        
                    if (patReg == null)
                    {
                        return NotFound();
                    }
        
                    var DataRes = new {
                        sdata = patReg
                    };
        
                    return Ok(DataRes);
         }
