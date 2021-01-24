    try
            {
                for (int j = 0; j < project.Slides[i].Labels.Count; j++)
                {
                    string pageContext = project.Slides[i].Labels[j].Text;
                    int fontNumber = Convert.ToInt32(project.Slides[i].Labels[j].Font);
                    int fontSize = Convert.ToInt32(project.Slides[i].Labels[j].Size);
                    float fontSizePoints = (float)fontSize * (float)2.1;
                    string fontColor = project.Slides[i].Labels[j].Color;
                    float X = (float)project.Slides[i].Labels[j].X;
                    float Y = pHeightPoints - (float)project.Slides[i].Labels[j].Y;
                    float width = (float)project.Slides[i].Labels[j].Widht;
                    float height = (float)project.Slides[i].Labels[j].Heigh;
                    float llx = X;
                    float lly = Y + height;
                    float urx = X + width;
                    float ury = Y;
                    var color = System.Drawing.ColorTranslator.FromHtml(fontColor);
                    baseFont = GetBaseFont(fontNumber);
                    float w = baseFont.GetWidthPoint(pageContext, fontSizePoints);
                    Font dFont = new Font(baseFont, fontSizePoints);
                    dFont.Color = new BaseColor(color);
                    PlaceText(writer.DirectContent, pageContext, 
                        new Font(baseFont, fontSizePoints, 
                            Font.NORMAL,
                            new BaseColor(color)), llx, lly, urx, ury, 14, 
                            Element.ALIGN_RIGHT);
                }
            }
            catch (Exception)
            {
            }
