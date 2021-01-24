     wrdRng.SetRange(OUTERTABLE.Cell(2, 2).Range.Start, OUTERTABLE.Cell(2, 2).Range.Start);
  *
    Application oWord;
            Document oDoc;
            oWord = new Application();
            oWord.Visible = true;
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
               ref oMissing, ref oMissing);
            Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
           Table OUTERTABLE = oDoc.Tables.Add(wrdRng, 3, 3, ref oMissing, ref oMissing);
            OUTERTABLE.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            OUTERTABLE.Borders.OutsideColor = WdColor.wdColorBlack;
            OUTERTABLE.TableDirection = WdTableDirection.wdTableDirectionLtr;
            OUTERTABLE.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            OUTERTABLE.Borders.InsideColor = WdColor.wdColorBlack;
            object oDocTables = oDoc.Tables;
            object objCell = InvokeMethod(OUTERTABLE, "Cell", new object[] { 2, 2 });
            object objTR = GetProperty(objCell, "Range", null);
            wrdRng.SetRange(OUTERTABLE.Cell(2, 2).Range.Start, OUTERTABLE.Cell(2, 2).Range.Start);
            Table INNERTABLE = OUTERTABLE.Tables.Add(wrdRng, 2, 2, ref oMissing, ref oMissing);
            INNERTABLE.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            INNERTABLE.Borders.OutsideColor = WdColor.wdColorBlack;
            INNERTABLE.TableDirection = WdTableDirection.wdTableDirectionLtr;
            INNERTABLE.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            INNERTABLE.Borders.InsideColor = WdColor.wdColorBlack;
