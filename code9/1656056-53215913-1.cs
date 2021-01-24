        /// <summary>
        /// Select an painted area of canvas by finding the top, the bottom, the right border and the left border of letter.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>An croped image with no white borders.</returns>
        public static Bitmap CalculateRectangle(Bitmap p)
        {
            int TopMost = 0;
            int RightBorder = 0;
            int BotomMost = 0;
            int LeftBorder = 0;
            //maxH
            bool flag = false;
            for (int i = 0; i < p.Height; i++)
            {
                for (int j = 0; j < p.Width; j++)
                {
                    if (!IsWhitePixel(p.GetPixel(j, i)))
                    {
                        TopMost = i;
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            //minH
            flag = false;
            for (int i = p.Height - 1; i >= 0; i--)
            {
                for (int j = 0; j < p.Width; j++)
                {
                    if (!IsWhitePixel(p.GetPixel(j, i)))
                    {
                        BotomMost = i;
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            //left
            flag = false;
            for (int j = 0; j < p.Width; j++)
            {
                for (int i = TopMost; i <= BotomMost; i++)
                {
                    if (!IsWhitePixel(p.GetPixel(j, i)))
                    {
                        LeftBorder = j;
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            //right
            flag = false;
            for (int j = p.Width - 1; j >= 0; j--)
            {
                for (int i = TopMost; i <= BotomMost; i++)
                {
                    if (!IsWhitePixel(p.GetPixel(j, i)))
                    {
                        RightBorder = j;
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            return CropImage(p, new Rectangle(new System.Drawing.Point(LeftBorder, TopMost), new System.Drawing.Size(RightBorder - LeftBorder + 1, BotomMost - TopMost + 1)));
        }
