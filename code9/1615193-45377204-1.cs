	public static bool MergePDFs(IEnumerable<string> fileNames, string targetPdf)
	{
		var merged = true;
		using (var stream = new FileStream(targetPdf, FileMode.Create))
		{
			var document = new Document();
			var pdf = new PdfCopy(document, stream);
			PdfReader reader = null;
			try
			{
				document.Open();
				foreach (var file in fileNames)
				{
					reader = new PdfReader(file);
					pdf.AddDocument(reader);
					reader.Close();
				}
			}
			catch (Exception)
			{
				merged = false;
				reader?.Close();
			}
			finally
			{
				document.Close();
			}
		}
		return merged;
	}
