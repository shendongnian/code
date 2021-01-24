    private void AddChartTitle(DocumentFormat.OpenXml.Drawing.Charts.Chart chart,string title)
        {
            var ctitle = chart.AppendChild(new Title());
            var chartText = ctitle.AppendChild(new ChartText());
            var richText = chartText.AppendChild(new RichText());
    
            var bodyPr = richText.AppendChild(new BodyProperties());
            var lstStyle = richText.AppendChild(new ListStyle());
            var paragraph = richText.AppendChild(new Paragraph());
    
            var apPr = paragraph.AppendChild(new ParagraphProperties());
            apPr.AppendChild(new DefaultRunProperties());
    
            var run = paragraph.AppendChild(new DocumentFormat.OpenXml.Drawing.Run());
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.RunProperties() { Language = "en-CA" });
            run.AppendChild(new DocumentFormat.OpenXml.Drawing.Text() { Text = title });
        }
