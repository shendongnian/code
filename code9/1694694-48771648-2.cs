            ConverterProperties props = new ConverterProperties();
            FontProvider fp = new FontProvider();
            fp.AddStandardPdfFonts();
            props.SetFontProvider(fp);
            DefaultTagWorkerFactory tagWorkerFactory = new AccessibilityTagWorkerFactory();
            props.SetTagWorkerFactory(tagWorkerFactory);
            HtmlConverter.ConvertToPdf(html, pdfDoc, props);
            pdfDoc.Close();
