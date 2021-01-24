    Phrase p2 = new Phrase();
                if (i == 3)
                {
                    pdfDoc.NewPage();
                    p2.Add(line1);
                    p2.Add(new Paragraph("\n"));
                    p2.Add(new Paragraph("\n"));
                    p2.Add(line2);
                    p2.Add(new Paragraph("\n"));
                    p2.Add(hr);
                    p2.Add(new Paragraph("\n"));
                    i = 0;
                }
                i++; 
