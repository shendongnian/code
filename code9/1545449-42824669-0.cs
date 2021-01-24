       foreach (DataRow dr in dt.Rows)
                {
               
                    //Table Cell css style 
                    var tableCell = new PdfPCell();
                    tableCell.BorderColor = Color.WHITE;
                    tableCell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    tableCell.HorizontalAlignment = PdfCell.PARAGRAPH;
                    tableCell.PaddingBottom = 3f;
                    tableCell.PaddingTop = 0f;
                    tableCell.PaddingLeft = 1f;
                    string fontpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Calibri.TTF";
                    ////Path to our font
                    //string arialuniTff = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontpath);
                    ////Register the font with iTextSharp
                    //iTextSharp.text.FontFactory.Register(arialuniTff);
                    //Register font with iTextSharp
                    FontFactory.Register(fontpath, "Calibri");
                    StyleSheet styles = new StyleSheet();
                    styles.LoadTagStyle("body", "face", "Calibri"); ;
                    styles.LoadTagStyle("body", "encoding", "Identity-H");
                    styles.LoadTagStyle("p", "size", "10px");
                    styles.LoadTagStyle("p", "line-height", "2px");
                    styles.LoadTagStyle("a", "text-decoration", "underline");
                    styles.LoadTagStyle("a", "color", "blue");
                 
                    //Convert citation into html format.
                   foreach (IElement element in HTMLWorker.ParseToList(new StringReader("<p>" +dr["Citation"].ToString()+ "</p>"),styles))
                    {
                        tableCell.AddElement(element);
                    }
                   table.AddCell(tableCell);
                }
    
