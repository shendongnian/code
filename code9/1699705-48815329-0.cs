        using (MemoryStream ms = new MemoryStream())
        {
            chart1.SaveImage(ms, ChartImageFormat.Bmp);
            Bitmap bm = new Bitmap(ms);
            Clipboard.SetImage(bm);
        }
        RichTextBox rtbCombination = new RichTextBox();
        rtbCombination.Rtf = ucLegend.rtbContents.Rtf;
        rtbCombination.Select(rtbCombination.Rtf.Length, 0);
        rtbCombination.AppendText(Environment.NewLine);
        rtbCombination.Select(rtbCombination.Rtf.Length, 0);
        rtbCombination.Paste();
        Clipboard.SetText(rtbCombination.Rtf, TextDataFormat.Rtf);
