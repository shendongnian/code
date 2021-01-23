            bool hasNumberPages = false;
			Word.Document doc = WordApp.ActiveDocument;
			try
			{
				Word.HeaderFooter headOrFooter = null;
				Word.Section section = null;
				for (int i = 1; i <= doc.Sections.Count; i++)
				{
					try
					{
						section = doc.Sections[i];
						if(section != null)
						{
							headOrFooter = section.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
							headOrFooter = section.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
							headOrFooter = section.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
							headOrFooter = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
							headOrFooter = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterEvenPages];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
							headOrFooter = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterFirstPage];
							hasNumberPages = HeaderOrFooterHasPageNumber(headOrFooter);
							if (hasNumberPages)
								break;
						}
					}
					finally
					{
						if(headOrFooter != null)
						{
							Marshal.ReleaseComObject(headOrFooter);
							headOrFooter = null;
						}
						if (section != null)
							Marshal.ReleaseComObject(section);
					}
				}
			}
			finally
			{
				if (doc != null)
					Marshal.ReleaseComObject(doc);
			}
