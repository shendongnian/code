    public async Task<IActionResult> Create(PatReg patReg)
    {
        if (ModelState.IsValid)
        {
            var seq = await _context.FileIdSeq.FromSql("FileIdSeqSP").ToListAsync();
            var keys = await _context.EncKeys.FromSql("EncKeysSP").ToListAsync();
            patReg.FileId = DbSerializerHandler.SerializeFileId(seq); 
            patReg.SNN = DbEncryptionHandler.DynamicEncrypt(patReg.SNN, keys);
            _context.Add(patReg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(patReg);
    } 
