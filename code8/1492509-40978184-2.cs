    [ResponseType(typeof(Vocab))]
    public async Task<IHttpActionResult> GetVocabByLesson(int lessonId)
    {
            var result= await db.Vocabs.Where(a => a.LessonId == lessonId).ToListAsync();
            if (!result.Any())
                return NotFound();
    
            return Ok(result);
    }
