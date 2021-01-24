    var writer = PdfWriter.GetInstance(document, output);
    document.Open();
    string webURL = "http://www.apache.org/foundation/press/kit/feather.png";
    Image webIcon = Image.GetInstance(webURL);
    webIcon.Annotation = new Annotation(0, 0, 0, 0, "http://www.google.com");
    webIcon.ScaleAbsolute(35f, 35f);
    webIcon.SetAbsolutePosition(227, 23);
    PdfContentByte canvas = writer.DirectContentUnder;
    canvas.SaveState();
    PdfGState state = new PdfGState();
    state.FillOpacity = 0.6f; // THIS is where you set opacity
    canvas.SetGState(state);
    canvas.AddImage(webIcon);
    canvas.RestoreState();  
    document.Close();
