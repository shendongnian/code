    public List<string> getColors(int columns)
        {
            List<string> colors = new List<string>();
            colors.Add("\"rgba(77,77,77,0.8)\"");
            colors.Add("\"rgba(241,88,84,0.8)\"");
            colors.Add("\"rgba(93,165,218,0.8)\"");
            colors.Add("\"rgba(96,189,104,0.8)\"");
            colors.Add("\"rgba(222,207,63,0.8)\"");
            colors.Add("\"rgba(178,118,178,0.8)\"");
            colors.Add("\"rgba(187,253,241,0.8)\"");
            colors.Add("\"rgba(178,145,47,0.8)\"");
            if (columns > colors.Count)
            {
                while (true)
                {
                    Color c = GetRandomColour();
                    string cs = String.Format("\"rgba({0},{1},{2},0.8)\"", c.R.ToString(), c.G.ToString(), c.B.ToString());
                    if (!colors.Contains(cs))
                    {
                        colors.Add(cs);
                        break;
                    }
                }
            }
            return colors;
        }
