    var query = db.Phrases.AsQueryable();
    bool categoryFilter = options.CategorySelectId != null && options.PhraseTypeSelectId != 2;
    bool chapterFilter = options.ChapterSelectId != null && options.PhraseTypeSelectId != 1;
    if (categoryFilter && chapterFilter) query = query
        .Where(w => w.CategoryId == options.CategorySelectId || w.ChapterId == options.ChapterSelectId);
    else if (categoryFilter) query = query
        .Where(w => w.CategoryId == options.CategorySelectId);
    else if (chapterFilter) query = query
       .Where(w => w.ChapterId == options.ChapterSelectId);
    query = query
        .Where(w => (w.EnglishAscii >= es1 && w.EnglishAscii <= ee1) || (w.EnglishAscii >= es2 && w.EnglishAscii <= ee2))
        .Where(w => (w.RomajiAscii >= rs1 && w.RomajiAscii <= re1) || (w.RomajiAscii >= rs2 && w.RomajiAscii <= ee2));
    if (options.CreatedBy != 0) query = query
        .Where(w => w.CreatedBy == options.CreatedBy);
    if (options.ModifiedBy != 0)
        query = query.Where(w => w.ModifiedBy == options.ModifiedBy);
    if (options.JLPT != 0)
        query = query.Where(w => w.JLPT == options.JLPT);
    var phrases = await query
        .AsNoTracking()
        .ToListAsync();
    return Ok(phrases);
 
