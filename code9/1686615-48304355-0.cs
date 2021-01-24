            Application wordApp = new Word.Application();
            Document wordDoc = wordApp.Documents.Add();
            float scaledWidth;
            float scaledHeight;
            object oCollapseEnd = WdCollapseDirection.wdCollapseEnd;
            InlineShape finalInlineShape;
            Range inlineShapeRange;
            inlineShapeRange = wordDoc.Content;
            
            foreach (var filepath in path)
            {
                finalInlineShape = wordDoc.InlineShapes.AddPicture(filepath, false, true, inlineShapeRange);
                scaledWidth = finalInlineShape.Width;
                scaledHeight = finalInlineShape.Height;
                //autoScaledInlineShape.Delete();
                finalInlineShape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                inlineShapeRange.InsertParagraphAfter;
                inlineShapeRange.Collapse(ref oCollapseEnd);
                //finalInlineShape.Range.Cut();
                //docRange = wordDoc.Range();
                //docRange.Paste();
            }   
            wordDoc.SaveAs2(@"C:\test\Project.docx");
            wordDoc.Close();
            wordApp.Quit();
