    public static void CreateWordprocessingDocument(string filepath)
    {
        string documentPath = filepath;
        using (WordprocessingDocument package =
            WordprocessingDocument.Create(
            documentPath, WordprocessingDocumentType.Document))
        {
            AddParts(package);
        }
    }
    private static void AddParts(WordprocessingDocument parent)
    {
        var mainDocumentPart = parent.AddMainDocumentPart();
        GenerateMainDocumentPart().Save(mainDocumentPart);
        var documentSettingsPart =
            mainDocumentPart.AddNewPart
            <DocumentSettingsPart>("rId1");
        GenerateDocumentSettingsPart().Save(documentSettingsPart);
        var firstPageHeaderPart =
            mainDocumentPart.AddNewPart<HeaderPart>("rId2");
        GeneratePageHeaderPart(
            "First page header").Save(firstPageHeaderPart);
        var firstPageFooterPart =
            mainDocumentPart.AddNewPart<FooterPart>("rId3");
        GeneratePageFooterPart(
            "First page footer").Save(firstPageFooterPart);
        var evenPageHeaderPart =
            mainDocumentPart.AddNewPart<HeaderPart>("rId4");
        GeneratePageHeaderPart(
            "Even page header").Save(evenPageHeaderPart);
        var evenPageFooterPart =
            mainDocumentPart.AddNewPart<FooterPart>("rId5");
        GeneratePageFooterPart(
            "Even page footer").Save(evenPageFooterPart);
        var oddPageheaderPart =
            mainDocumentPart.AddNewPart<HeaderPart>("rId6");
        GeneratePageHeaderPart(
            "Odd page header").Save(oddPageheaderPart);
        var oddPageFooterPart =
            mainDocumentPart.AddNewPart<FooterPart>("rId7");
        GeneratePageFooterPart(
            "Odd page footer").Save(oddPageFooterPart);
    }
    private static Document GenerateMainDocumentPart()
    {
        var element =
            new Document(
                new Body(
                    new Paragraph(
                        new Run(
                            new Text("Page 1 content"))
                    ),
                    new Paragraph(
                        new Run(
                            new Break() { Type = BreakValues.Page })
                    ),
                    new Paragraph(
                        new Run(
                            new LastRenderedPageBreak(),
                            new Text("Page 2 content"))
                    ),
                    new Paragraph(
                        new Run(
                            new Break() { Type = BreakValues.Page })
                    ),
                    new Paragraph(
                        new Run(
                            new LastRenderedPageBreak(),
                            new Text("Page 3 content"))
                    ),
                    new Paragraph(
                        new Run(
                            new Break() { Type = BreakValues.Page })
                    ),
                    new Paragraph(
                        new Run(
                            new LastRenderedPageBreak(),
                            new Text("Page 4 content"))
                    ),
                    new Paragraph(
                        new Run(
                            new Break() { Type = BreakValues.Page })
                    ),
                    new Paragraph(
                        new Run(
                            new LastRenderedPageBreak(),
                            new Text("Page 5 content"))
                    ),
                    new SectionProperties(
                        new HeaderReference()
                        {
                            Type = HeaderFooterValues.First,
                            Id = "rId2"
                        },
                        new FooterReference()
                        {
                            Type = HeaderFooterValues.First,
                            Id = "rId3"
                        },
                        new HeaderReference()
                        {
                            Type = HeaderFooterValues.Even,
                            Id = "rId4"
                        },
                        new FooterReference()
                        {
                            Type = HeaderFooterValues.Even,
                            Id = "rId5"
                        },
                        new HeaderReference()
                        {
                            Type = HeaderFooterValues.Default,
                            Id = "rId6"
                        },
                        new FooterReference()
                        {
                            Type = HeaderFooterValues.Default,
                            Id = "rId7"
                        },
                        new PageMargin()
                        {
                            Top = 1440,
                            Right = (UInt32Value)1440UL,
                            Bottom = 1440,
                            Left = (UInt32Value)1440UL,
                            Header = (UInt32Value)720UL,
                            Footer = (UInt32Value)720UL,
                            Gutter = (UInt32Value)0UL
                        },
                        new TitlePage()
                    )));
        return element;
    }
    private static Footer GeneratePageFooterPart(string FooterText)
    {
        var element =
            new Footer(
                new Paragraph(
                    new ParagraphProperties(
                        new ParagraphStyleId() { Val = "Footer" }),
                    new Run(
                        new Text(FooterText))
                ));
        return element;
    }
    private static Header GeneratePageHeaderPart(string HeaderText)
    {
        var element =
            new Header(
                new Paragraph(
                    new ParagraphProperties(
                        new ParagraphStyleId() { Val = "Header" }),
                    new Run(
                        new Text(HeaderText))
                ));
        return element;
    }
    private static Settings GenerateDocumentSettingsPart()
    {
        var element =
            new Settings(new EvenAndOddHeaders());
        return element;
    }
