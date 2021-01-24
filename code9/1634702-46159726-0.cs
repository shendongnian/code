    this the example i did
    
    private void GeneratePdf()
            {
                string path = Server.MapPath("APP_Data");
                Document doc = new Document();
                try
                {
                    Guid newGd= Guid.NewGuid();
                    PdfWriter.GetInstance(doc, new FileStream(path + "/Anchors"+ newGd+".pdf", FileMode.Create));
                    doc.Open();
                    iTextSharp.text.Font link = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE);
                    Anchor anchor = new Anchor("www.mikesdotnetting.com", link);
                    anchor.Reference = "http://www.mikesdotnetting.com";
    
                    Anchor click = new Anchor("Click to go to Target");
                    click.Reference = "#target";
                    Paragraph p1 = new Paragraph();
                    p1.Add(click);
                    doc.Add(p1);
    
                    Paragraph p2 = new Paragraph();
                    p2.Add(new Chunk("\n\n\n\n\n\n\n\n"));
                    doc.Add(p2);
    
                    Anchor target = new Anchor("This is the Target");
                    target.Name = "target";
                    Paragraph p3 = new Paragraph();
                    p3.Add(target);
                    doc.Add(p3);
                    Paragraph p4 = new Paragraph();
                    p4.Add(new Chunk("Click "));
                    p4.Add(new Chunk("here", link).SetLocalGoto("GOTO"));
                    p4.Add(new Chunk(" to find local goto"));
                    p4.Add(new Chunk("\n\n\n\n\n\n\n\n\n"));
    
                    Paragraph p5 = new Paragraph();
                    p5.Add(new Chunk("Local Goto Destination").SetLocalDestination("GOTO"));
    
                    doc.Add(p4);
                    doc.Add(p5);
                    Chapter chapter1 = new Chapter(new Paragraph("This is Chapter 1"), 1);
                    Section section1 = chapter1.AddSection(20f, "Section 1.1", 2);
                    Section section2 = chapter1.AddSection(20f, "Section 1.2", 2);
                    Section subsection1 = section2.AddSection(20f, "Subsection 1.2.1", 3);
                    Section subsection2 = section2.AddSection(20f, "Subsection 1.2.2", 3);
                    Section subsubsection = subsection2.AddSection(20f, "Sub Subsection 1.2.2.1", 4);
                    Chapter chapter2 = new Chapter(new Paragraph("This is Chapter 2"), 1);
                    Section section3 = chapter2.AddSection("Section 2.1", 2);
                    Section subsection3 = section3.AddSection("Subsection 2.1.1", 3);
                    Section section4 = chapter2.AddSection("Section 2.2", 2);
                    chapter1.BookmarkTitle = "Changed Title";
                    chapter1.BookmarkOpen = true;
                    chapter2.BookmarkOpen = false;
                    doc.Add(chapter1);
                    doc.Add(chapter2);
                    doc.Add(anchor);
                }
                catch (DocumentException dex)
                {
                    Response.Write(dex.Message);
                }
                catch (IOException ioex)
                {
                    Response.Write(ioex.Message);
                }
                finally
                {
                    doc.Close();
                }
            }
