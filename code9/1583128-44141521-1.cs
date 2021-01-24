	else if (book.IT == IndexType.Modify)
	{
		document.Add(new Field("id", book.ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
		document.Add(new Field("title", book.Title, Field.Store.YES, Field.Index.ANALYZED,
							   Field.TermVector.WITH_POSITIONS_OFFSETS));
		document.Add(new Field("content", book.Starring, Field.Store.YES, Field.Index.ANALYZED,
							   Field.TermVector.WITH_POSITIONS_OFFSETS));
		writer.UpdateDocument(new Term("id", document));
	}
