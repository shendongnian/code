        public void DrawStringInTextboxes(string text, Graphics g)
        {
            String drawString = text;
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Fonts/Squidgingtons.ttf"));
            var squidingtonsFontFamily = fontCollection.Families[0];
            Font squidingtons = new Font(squidingtonsFontFamily, textParameters[0].MaxFontSize);
            Font drawFont = new Font("Arial", 60);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            char[] delimiterChars = { ' ' };
            string[] words = drawString.Split(delimiterChars);
            string finalString = "";
            int textBoxIndex = 0;
            foreach (string word in words)
            {
                //set the dimensions for the first textbox and create a rectangle with those specifications.
                float x = textParameters[textBoxIndex].Left;
                float y = textParameters[textBoxIndex].Top;
                float width = textParameters[textBoxIndex].Width;
                float height = textParameters[textBoxIndex].Height;
                RectangleF Rect = new RectangleF(x, y, width, height);
                //if the current finalString + the next word fits in the current box, add the word to finalString.
                if (g.MeasureString(finalString + word + " ", squidingtons).Width < textParameters[textBoxIndex].Width) 
                {     
                    finalString = finalString + " " + word;
                    //if this is the last word, print the finalString and we are done.
                    if (word == words[words.Length - 1])
                    {
                        g.DrawString(finalString, squidingtons, drawBrush, Rect, drawFormat);
                        break;
                    }
                }
                //the current finalString + next word did not fit in the box. Draw what we have to the first box.
                else {
                    g.DrawString(finalString, squidingtons, drawBrush, Rect, drawFormat);
                    //Hold onto the word that didnt fit. It will be the first word of the next box.
                    finalString = word;
                    if (textBoxIndex +1 >= textParameters.Length)
                    {
                        //if we are out of textboxes, we are done.
                        break;
                    }
                    else
                    {
                        //move on to the next textbox. The loop begins again with new specifications set for the textbox.
                        textBoxIndex++;
                    }
                }
               
            }
            squidingtons.Dispose();
            drawBrush.Dispose();
            drawFont.Dispose();
        }
