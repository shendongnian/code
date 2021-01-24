		if (annots != null)
		{
			for (int j = 0; j < annots.Size(); j++)
			{
				PdfDictionary annotItem = annots.GetAsDictionary(i);
				PdfLineAnnotation lineAnnotation = new PdfLineAnnotation(annotItem);
				page.AddAnnotation(lineAnnotation)
			}
		}
