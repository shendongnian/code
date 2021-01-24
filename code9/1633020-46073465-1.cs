        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatReg([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // 1 select Parent Record
            var PatientInfo = await _context.PatReg 
                .Where(a => a.FileId == id)
                .Select(b => new PatRegDto
                {
                    Action = "Get",
                    FileId = b.FileId,
                    FName = b.FName,
                    MName = b.MName,
                    LName = b.LName,
                    Dob = b.Dob,
                }).ToListAsync();
            // 2 select Child Record
            var PartnerInfo = await _context.PatPar.Select(m => new PatParDto 
            {
                RecId = m.RecId,
                FileId = m.FileId,
                ParFileId = m.ParFileId,
                SDate = m.SDate,
                EDate = m.EDate,
            }).ToListAsync();
            // 3 Fetch more data (not in the original model)
            for (int i = 0; i < PartnerInfo.Count; i++)
            {
                PartnerInfo[i].FullName = _context.PatReg.Where(a => a.FileId == PartnerInfo[i].ParFileId)
                                       .Select(t => new { t.fullname })
                                       .Single().fullname;
                PartnerInfo[i].dob = _context.PatReg.Where(a => a.FileId == PartnerInfo[i].ParFileId)
                                       .Select(t => new { t.Dob })
                                       .Single().Dob;
                PartnerInfo[i].Action = "Get";
            }
            
             // 4 Join parent and child data 
            for (int i = 0; i < PatientInfo.Count; i++)
            {
                PatientInfo[i].PartnerInfo = PartnerInfo.Where(a => a.FileId == PartnerInfo[i].FileId).ToList();
            }
            if (PatientInfo == null)
            {
                return NotFound();
            }
            var DataRes = new {
                sdata = PatientInfo
            };
            return Ok(DataRes);
        }
