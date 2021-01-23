    class PDFTextLocationStripper : PDFTextStripper
        {
            public string textWithPostion = "";
            public Dictionary<float, Dictionary<float, PdfWord>> pdfWordsByXByY;
           
            public PDFTextLocationStripper(): base()
            {
                try
                {
                    textWithPostion = "";
                    pdfWordsByXByY = new Dictionary<float, Dictionary<float, PdfWord>>();
                }
                catch (Exception ex)
                {
                 
                }
            }
    
            protected override void processTextPosition(TextPosition text)
            {
                try
                {
                    float textX = text.getXDirAdj();
                    float textY = text.getYDirAdj();
                    if (!String.IsNullOrWhiteSpace(text.getCharacter()))
                    {
                        if (pdfWordsByXByY.ContainsKey(textY))
                        {
                            Dictionary<float, PdfWord> wordsByX = pdfWordsByXByY[textY];
                            if (wordsByX.ContainsKey(textX))
                            {
                                PdfWord word = wordsByX[textX];
                                wordsByX.Remove(word.Right);
                                word.EndCharWidth = text.getWidthDirAdj();
                                word.Height = text.getHeightDir();
                                word.EndX = textX;
                                word.Text += text.getCharacter();
                                if (!wordsByX.Keys.Contains(word.Right))
                                {
                                    wordsByX.Add(word.Right, word);
                                }
                            }
                            else
                            {
                                float requiredX = -1;
                                float minDiff = float.MaxValue;
                                for (int index = 0; index < wordsByX.Keys.Count; index++)
                                {
                                    float key = wordsByX.Keys.ElementAt(index);
                                    float diff = key - textX;
                                    if (diff < 0)
                                    {
                                        diff = -diff;
                                    }
                                    if (diff < minDiff)
                                    {
                                        minDiff = diff;
                                        requiredX = key;
                                    }
                                }
                                if (requiredX > -1 && minDiff <= 1)
                                {
                                    PdfWord word = wordsByX[requiredX];
                                    wordsByX.Remove(requiredX);
                                    word.EndCharWidth = text.getWidthDirAdj();
                                    word.Height = text.getHeightDir();
                                    word.EndX = textX;
                                    word.Text += text.getCharacter();
                                    if (!wordsByX.ContainsKey(word.Right))
                                    {
                                        wordsByX.Add(word.Right, word);
                                    }
                                }
                                else
                                {
                                    PdfWord word = new PdfWord();
                                    word.Text = text.getCharacter();
                                    word.EndX = word.StartX = textX;
                                    word.Y = textY;
                                    word.EndCharWidth = word.StartCharWidth = text.getWidthDirAdj();
                                    word.Height = text.getHeightDir();
                                    if (!wordsByX.ContainsKey(word.Right))
                                    {
                                        wordsByX.Add(word.Right, word);
                                    }
                                    pdfWordsByXByY[textY] = wordsByX;
                                }
                            }
                        }
                        else
                        {
                            Dictionary<float, PdfWord> wordsByX = new Dictionary<float, PdfWord>();
                            PdfWord word = new PdfWord();
                            word.Text = text.getCharacter();
                            word.EndX = word.StartX = textX;
                            word.Y = textY;
                            word.EndCharWidth = word.StartCharWidth = text.getWidthDirAdj();
                            word.Height = text.getHeightDir();
                            wordsByX.Add(word.Right, word);
                            pdfWordsByXByY.Add(textY, wordsByX);
                        }
                    }
                }
                catch (Exception ex)
                {
                  
                }
            }
        }
