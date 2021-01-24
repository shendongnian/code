        private void DoFormatSections(Document docFormat, string strAuthor, string strTitle, string strCollectionTitle)
        {
            try
            {
                //  Three ranges to establish three sections, title, body and end statement
                Range rngTitlePage = null;
                Range rngBody = null;
                Range rngEndPage = null;
                //  Odd pages header
                HeaderFooter hPrimary = null;
                //  Even pages header
                HeaderFooter hEven = null;
                //  Odd pages footer
                HeaderFooter fPrimary = null;
                //  Even pages footer
                HeaderFooter fEven = null;
                //  Body begins at page three; (1 and 2 are title page)
                int nBodyBegin = 3;
                //  Body ends at third page from end (next to last is end remark and last is author about)
                int nBodyEnd = (int)docFormat.Paragraphs[docFormat.Paragraphs.Count].Range.get_Information(WdInformation.wdNumberOfPagesInDocument) - 1;
                // -1 = true; odd and even pages have separate header and footer; so, setup both
                docFormat.PageSetup.OddAndEvenPagesHeaderFooter = -1;
                //  Set start of begin and end of end from total document range (document will have one section containing everything by default)
                rngTitlePage = docFormat.Sections[1].Range;
                rngEndPage = docFormat.Sections[1].Range;
                //  Set the ranges of the three sections, range is by character index within the document
                //  Move to first character of body section
                wordApp.Selection.GoTo(WdGoToItem.wdGoToPage, WdGoToDirection.wdGoToAbsolute, nBodyBegin, null);
                rngTitlePage.End = wordApp.Selection.Range.Start - 1;
                rngBody = wordApp.Selection.Range;
                //  Move to last character of body section
                wordApp.Selection.GoTo(WdGoToItem.wdGoToPage, WdGoToDirection.wdGoToAbsolute, nBodyEnd, null);
                rngBody.End = wordApp.Selection.Range.Start - 1;
                rngEndPage.Start = wordApp.Selection.Range.Start;                
                //  Add two sections to document (order is unimportant for now, each section below sets the range appropriately for each section
                docFormat.Sections.Add(rngEndPage, WdSectionStart.wdSectionContinuous);
                docFormat.Sections.Add(rngBody, WdSectionStart.wdSectionContinuous);
                //  Disconnect second section (body) from first and third sections;  set section section (body) header and footer
                if (docFormat.Sections.Count >= 2)
                {
                    //  Ensure odd/even header/footer is separated for this section
                    docFormat.Sections[2].PageSetup.OddAndEvenPagesHeaderFooter = -1;
                    //  Set section range, body
                    docFormat.Sections[2].Range.Start = rngBody.Start;
                    docFormat.Sections[2].Range.End = rngBody.End;
                    //  Odd page footer:  collection title
                    fPrimary = docFormat.Sections[2].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if (fPrimary != null)
                    {
                        //  Disconnect this footer from previous section
                        fPrimary.LinkToPrevious = false;
                        //  Set and format footer text
                        fPrimary.Range.Text = strCollectionTitle;
                        fPrimary.Range.Font.Name = "Arial";
                        fPrimary.Range.Font.Size = 10;
                        fPrimary.Range.Select();
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    //  Even page footer:  collection title
                    fEven = docFormat.Sections[2].Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if (fEven != null)
                    {
                        //  Disconnect this footer from previous section
                        fEven.LinkToPrevious = false;
                        //  Set and format footer text
                        fEven.Range.Text = strCollectionTitle;
                        fEven.Range.Font.Name = "Arial";
                        fEven.Range.Font.Size = 10;
                        fEven.Range.Select();
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    //  Odd page header
                    hPrimary = docFormat.Sections[2].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if(hPrimary != null)
                    {
                        //  Disconnect this header from previous section
                        hPrimary.LinkToPrevious = false;
                        //  Odd page number header:  Title -> PageNumber
                        //  Page number MUST come first (it deletes all existing header text, if later)
                        PageNumber pnPrimary = null;
                        hPrimary.PageNumbers.RestartNumberingAtSection = true;
                        hPrimary.PageNumbers.StartingNumber = 1;
                        //hPrimary.PageNumbers.ShowFirstPageNumber = true;
                        pnPrimary = hPrimary.PageNumbers.Add(WdPageNumberAlignment.wdAlignPageNumberRight, true);
                        if (pnPrimary != null)
                            pnPrimary.Alignment = WdPageNumberAlignment.wdAlignPageNumberRight;
                        hPrimary.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        //  Move to start of header
                        hPrimary.Range.Select();
                        wordApp.Selection.Collapse(WdCollapseDirection.wdCollapseStart);
                        //  Insert alignment tab
                        wordApp.Selection.Range.InsertAlignmentTab((int)WdAlignmentTabAlignment.wdRight, (int)WdAlignmentTabRelative.wdMargin);
                        //  Move again to start of header
                        hPrimary.Range.Select();
                        wordApp.Selection.Collapse(WdCollapseDirection.wdCollapseStart);
                        //  Set selection range text (NOT the range text on the hPrimary object)
                        wordApp.Selection.Range.InsertBefore(strTitle);
                        wordApp.Selection.Range.Font.Name = "Arial";
                        wordApp.Selection.Range.Font.Size = 10;
                        //wordApp.Selection.Range.Select();
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                    }
                    //  Even page header
                    hEven = docFormat.Sections[2].Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if(hEven != null)
                    {
                        //  Disconnect this header from previous section
                        hEven.LinkToPrevious = false;
                        //  Even page number header:  PageNumber -> Author
                        //  Page number MUST come first (it deletes all existing header text, if later)
                        PageNumber pnEven = null;
                        pnEven = hEven.PageNumbers.Add(WdPageNumberAlignment.wdAlignPageNumberLeft, true);
                        if (pnEven != null)
                            pnEven.Alignment = WdPageNumberAlignment.wdAlignPageNumberLeft;
                        //  Move to end of header
                        hEven.Range.Select();
                        wordApp.Selection.Collapse(WdCollapseDirection.wdCollapseEnd);
                        //  Insert alignment tab
                        wordApp.Selection.Range.InsertAlignmentTab((int)WdAlignmentTabAlignment.wdRight, (int)WdAlignmentTabRelative.wdMargin);
                        //  Move again to end of header
                        hEven.Range.Select();
                        wordApp.Selection.Collapse(WdCollapseDirection.wdCollapseEnd);
                        //  Set selection range text (NOT the range text on the hEven object)
                        wordApp.Selection.Range.InsertAfter(strAuthor);
                        wordApp.Selection.Range.Font.Name = "Arial";
                        wordApp.Selection.Range.Font.Size = 10;
                        wordApp.Selection.Range.Select();
                        wordApp.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                    }
                }
                //  Clear first section header and footer
                if (docFormat.Sections.Count >= 1)
                {
                    //  Ensure odd/even header/footer is separated for this section
                    docFormat.Sections[1].PageSetup.OddAndEvenPagesHeaderFooter = -1;
                    //  Set section range, body
                    docFormat.Sections[1].Range.Start = rngTitlePage.Start;
                    docFormat.Sections[1].Range.End = rngTitlePage.End;
                    //  Odd page header, clear
                    hPrimary = docFormat.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if (hPrimary != null)
                    {
                        //  Disconnect, select and clear
                        hPrimary.LinkToPrevious = false;
                        hPrimary.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Even page header, clear
                    hEven = docFormat.Sections[1].Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if (hEven != null)
                    {
                        //  Disconnect, select and clear
                        hEven.LinkToPrevious = false;
                        hEven.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Odd page footer, clear
                    fPrimary = docFormat.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if (fPrimary != null)
                    {
                        //  Disconnect, select and clear
                        fPrimary.LinkToPrevious = false;
                        fPrimary.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Even page footer, clear
                    fEven = docFormat.Sections[1].Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if (fEven != null)
                    {
                        //  Disconnect, select and clear
                        fEven.LinkToPrevious = false;
                        fEven.Range.Select();
                        wordApp.Selection.Delete();
                    }
                }
                //  Clear third section header and footer
                if (docFormat.Sections.Count >= 3)
                {
                    //  Ensure odd/even header/footer is separated for this section
                    docFormat.Sections[3].PageSetup.OddAndEvenPagesHeaderFooter = -1;
                    //  Set section range, body
                    docFormat.Sections[3].Range.Start = rngTitlePage.Start;
                    docFormat.Sections[3].Range.End = rngTitlePage.End;
                    //  Odd page header, clear
                    hPrimary = docFormat.Sections[3].Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if (hPrimary != null)
                    {
                        //  Disconnect, select and clear
                        hPrimary.LinkToPrevious = false;
                        hPrimary.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Even page header, clear
                    hEven = docFormat.Sections[3].Headers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if (hEven != null)
                    {
                        //  Disconnect, select and clear
                        hEven.LinkToPrevious = false;
                        hEven.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Odd page footer, clear
                    fPrimary = docFormat.Sections[3].Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    if (fPrimary != null)
                    {
                        //  Disconnect, select and clear
                        fPrimary.LinkToPrevious = false;
                        fPrimary.Range.Select();
                        wordApp.Selection.Delete();
                    }
                    //  Even page footer, clear
                    fEven = docFormat.Sections[3].Footers[WdHeaderFooterIndex.wdHeaderFooterEvenPages];
                    if (fEven != null)
                    {
                        //  Disconnect, select and clear
                        fEven.LinkToPrevious = false;
                        fEven.Range.Select();
                        wordApp.Selection.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error [DoFormatSections]: " + ex);
            }
            return;
        }
