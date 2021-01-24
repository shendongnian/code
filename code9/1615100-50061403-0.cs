            var table = new PdfFlowTableContent(1);
            //column width in %
            table.Columns[0].Width = 100;
            
            var row = table.Rows.Add();
            row.EnableRowSplit = false;
            var cell = new PdfFlowTableCompositeCell();
            
            //text
            cell.Content.Add(new PdfFlowTextContent(new PdfFormattedContent(KswModuleTranslator.PdfFaultReportStationAssuranceText)));
            //image
            var image = new PdfPngImage(new MemoryStream(signatureData.Signature));
            var imgDings = new PdfFlowImageContent(image);
            cell.Content.Add(imgDings);
            //text
            cell.Content.Add(new PdfFlowTextContent(new PdfFormattedContent(signatureInfo.SigneeName)));
            row.Cells.Add(cell);
            document.AddContent(table);
