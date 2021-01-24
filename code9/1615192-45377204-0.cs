	private SaveResult WritePDF(ref List<OrderLineItem> saveObj)
	{
		try
		{
			if (saveObj == null) throw new ArgumentNullException("Save Object is null");
			var theForm = ReadResource("LineItemOrderForm");
			var pageCount = 1.0;
			var multiPage = (saveObj.Count > 36);
			var multiList = new List<List<OrderLineItem>>();
			var fileList = new List<string>();
			if (multiPage)
			{
				var temp = (saveObj.Count / 36.0);
				pageCount = Math.Ceiling(temp);
				multiList = saveObj.ChunkBy(36);
			}
			else
			{
				multiList.Add(saveObj);
			}
			var sfd = new SaveFileDialog
			{
				AddExtension = true,
				InitialDirectory = DesktopPath,
				DefaultExt = ".pdf",
				RestoreDirectory = true,
				FileName = "Pioneer Order Form",
				Filter = "Adobe PDF Files (.pdf)|*.pdf",
			};
			var saveResult = sfd.ShowDialog();
			if (saveResult == false) return SaveResult.Cancelled;
			var fileName = sfd.FileName;
			var timesBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "TIMESBD.TTF");
			var timesBaseFont = BaseFont.CreateFont(timesBasePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			var pageNumber = 1;
			foreach (var page in multiList)
			{
				var tempFileName = Path.Combine(BasePath, Extensions.TempPdfName());
				fileList.Add(tempFileName);
				using (var pdfReader = new PdfReader(theForm))
				{
					var fs = new FileStream(tempFileName, FileMode.Create);
					using (var pdfStamper = new PdfStamper(pdfReader, fs))
					{
						var form = pdfStamper.AcroFields;
						form.AddSubstitutionFont(timesBaseFont);
						var i = 1;
						form.SetField("OrderFormDealerName", Constants.DealerName);
						form.SetFieldProperty("OrderFormDealerName", "textcolor", BaseColor.BLACK, null);
						form.SetField("PageNumber", pageNumber);
						form.SetField("TotalPages", Convert.ToInt32(pageCount));
						foreach (var item in page)
						{
							form.SetField($"LineItem{i:D2}", item.LineItemNumber);
							form.SetFieldProperty($"LineItem{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"Qty{i:D2}", item.Quantity);
							form.SetFieldProperty($"Qty{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"PartNumber{i:D2}", item.PartNumber);
							form.SetFieldProperty($"PartNumber{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"Hinging{i:D2}", item.Hinging);
							form.SetFieldProperty($"Hinging{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"Finished{i:D2}", item.Finished);
							form.SetFieldProperty($"Finished{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"UnitPrice{i:D2}", $"{item.UnitPrice:C0}");
							form.SetFieldProperty($"UnitPrice{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"ModPrice{i:D2}", $"{item.ModifyPrice:C0}");
							form.SetFieldProperty($"ModPrice{i:D2}", "textcolor", BaseColor.BLACK, null);
							form.SetField($"ExtPrice{i:D2}", $"{item.ExtendedPrice:C0}");
							form.SetFieldProperty($"ExtPrice{i:D2}", "textcolor", BaseColor.BLACK, null);
							i++;
						}
						pdfStamper.FormFlattening = true;
						pdfStamper.Close();
					}
					pdfReader.Close();
				}
				pageNumber++;
			}
			
			var result = MergePDFs(fileList, fileName);
			foreach (var file in fileList)
			{
				File.Delete(file);
			}
			return result ? SaveResult.Success : SaveResult.Failure;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "WritePdf()");
			return SaveResult.Failure;
		}
	}
