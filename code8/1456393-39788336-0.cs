    // common filters here:
    var filtered = db.Phrases
           .Where(w => (w.EnglishAscii >= es1 && w.EnglishAscii <= ee1) || (w.EnglishAscii >= es2 && w.EnglishAscii <= ee2))
           .Where(w => (w.RomajiAscii >= rs1 && w.RomajiAscii <= re1) || (w.RomajiAscii >= rs2 && w.RomajiAscii <= ee2))
           .Where(w => (options.CreatedBy == 0 || w.CreatedBy == options.CreatedBy))
           .Where(w => (options.ModifiedBy == 0 || w.ModifiedBy == options.ModifiedBy))
           .Where(w => (options.JLPT == 0 || w.JLPT == options.JLPT));
        // specific filters
        switch (options.PhraseTypeSelectId)
        {
            case 0:
                filtered = filtered 
                    .Where(w => ((w.CategoryId == options.CategorySelectId || options.CategorySelectId == null) ||
                             (w.ChapterId == options.ChapterSelectId || options.ChapterSelectId == null)))
                 break;
            case 1:
                filtered = filtered 
                    .Where(w => ((w.CategoryId == options.CategorySelectId || options.CategorySelectId == null)))
                 break;
            case 2:
                // ???
                 break;
            default: 
               return BadRequest();
        }
        var phrases = async filtered
            .AsNoTracking()
            .ToListAsync();
        return Ok(phrases);
