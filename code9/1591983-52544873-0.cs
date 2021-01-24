    using System;
	using System.IO;
	using System.Drawing;
	using iTextSharp.text.pdf;
	using iTextSharp.text;
	public static void UnRotate(string inputPath, string outputPath)
	{
		using (Document document = new Document())
		{
			using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create)))
			{
				using(PdfReader reader = new PdfReader(inputPath))
				{
					document.Open();
					PdfContentByte cb = writer.DirectContent;
					int pages = reader.NumberOfPages;
					for (int i = 1; i <= pages; i++)
					{
						iTextSharp.text.Rectangle psize = reader.GetPageSizeWithRotation(i);
						document.SetPageSize(psize.Width > psize.Height ? PageSize.LETTER.Rotate() : PageSize.LETTER);
						document.NewPage();
						PdfImportedPage page = writer.GetImportedPage(reader, i);
						switch (psize.Rotation)
						{
							case 0:
								writer.DirectContent.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
								break;
							case 90:
								writer.DirectContent.AddTemplate(page, 0, -1f, 1f, 0, 0, psize.Height);
								break;
							case 180:
								writer.DirectContent.AddTemplate(page, -1f, 0, 0, -1f, psize.Width, psize.Height);
								break;
							case 270:
								writer.DirectContent.AddTemplate(page, 0, 1f, -1f, 0, psize.Width, 0);
								break;
							default:
								throw new InvalidOperationException(string.Format("Unexpected page rotation: [{0}].", psize.Rotation));
						}
					}
					document.Close();
				}
				writer.Close();
			}
		}
	}
