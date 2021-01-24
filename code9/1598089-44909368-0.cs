    for (var i = 0; i <= data.GetUpperBound(0); i++)
    {
        var tr = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
        for (var j = 0; j <= data.GetUpperBound(1); j++)
        {
            var tc = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
            var paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
            var run = new DocumentFormat.OpenXml.Wordprocessing.Run();
            var text = new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]);
            // your old code for reference:  tc.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));
            RunProperties runProperties1 = new RunProperties();
            FontSize fontSize1 = new FontSize(){ Val = "36" };
            runProperties1.Append(fontSize1);
            run.Append(runProperties1);
            run.Append(text);
            
            paragraph.Append(run);
            tc.Append(paragraph);
            tr.Append(tc);
        }
        table.Append(tr);
    }
