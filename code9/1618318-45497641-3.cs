    public Int64 GetSerial()
        {
            List<FileIdSeq> NewFileSeq = new List<FileIdSeq>();
            NewFileSeq = _context.FileIdSeq.FromSql("FileIdSeqSP").ToList();
            var FileID = NewFileSeq[0].LastSequence;
            return FileID;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FName,MName,LName,Dob")] PatReg patReg)
        {
            if (ModelState.IsValid)
            {
                patReg.FileId = GetSerial();
                _context.Add(patReg);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patReg);
        }
