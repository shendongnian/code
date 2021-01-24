		public IQueryable<BookVerse> FindByVerseReferences(string bookCode, params VerseReference[] verseReferences)
		{
			var predicateBuilder = PredicateBuilder.New<BookVerse>();
			Expression<Func<BookVerse, bool>> predicate = null;
			foreach(VerseReference verseReference in verseReferences ?? new VerseReference[0])
			{
				Expression<Func<BookVerse, bool>> conditions = (x =>
						x.BookCode == bookCode
						&& x.Chapter == verseReference.Chapter
						&& x.FirstVerse <= verseReference.LastVerse
						&& x.LastVerse >= verseReference.FirstVerse);
				predicate = predicateBuilder.Or(conditions);
			}
			return ObjectSpace.BookVerses.AsExpandable().Where(predicate);
		}
