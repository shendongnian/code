        [HttpGet]
        public async Task<IEnumerable<Word>> Get()
        {
            return _db.Words.Select(x => new  
                          {
                              Word = x,
                              AuthorName = x.Author.UserName
                          }
                      ).ToList();
        }
