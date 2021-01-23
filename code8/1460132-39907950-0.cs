		private int last_printed_page;
		public void printPageNumber(int page_number = -1)
		{
			if (page_number == -1)
				page_number = writer.CurrentPageNumber;
			if (last_printed_page != numero)
			{
				PdfContentByte cb = writer.DirectContent;
				BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
				cb.BeginText();
				cb.SetFontAndSize(bf, 10);
				cb.ShowTextAligned((int)Doc.RightMargin, "" + numero, Doc.PageSize.Width - Doc.RightMargin - 5, 20, 0);
				cb.EndText();
				last_printed_page = page_number;
			}
		}
