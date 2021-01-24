    private static Stylesheet CreateStyles()
    {
        Stylesheet styleSheet = new Stylesheet();
        NumberingFormats nfs = new NumberingFormats();
        NumberingFormat nf;
        nf = new NumberingFormat();
        nf.NumberFormatId = 165;
        nf.FormatCode = "m/d/yyyy\\ h:mm\\ AM/PM";
        nfs.Append(nf);
        CellFormat cf = new CellFormat();
        cf.NumberFormatId = nf.NumberFormatId;
        cf.ApplyNumberFormat = true;
        CellFormats cfs = new CellFormats();
        cfs.Append(cf);
        styleSheet.CellFormats = cfs;
        styleSheet.NumberingFormats = nfs;
        styleSheet.Borders = new Borders();
        styleSheet.Borders.Append(new Border());
        styleSheet.Fills = new Fills();
        styleSheet.Fills.Append(new Fill());
        styleSheet.Fonts = new Fonts();
        styleSheet.Fonts.Append(new Font());
        CellStyles css = new CellStyles();
        CellStyle cs = new CellStyle();
        cs.FormatId = 0;
        cs.BuiltinId = 0;
        css.Append(cs);
        css.Count = UInt32Value.FromUInt32((uint)css.ChildElements.Count);
        styleSheet.Append(css);
        return styleSheet;
    }
