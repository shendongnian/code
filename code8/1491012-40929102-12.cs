    private void Form_MouseMove(object sender, MouseEventArgs e)
    {
        Graphics g = this.CreateGraphics();
        int characterCount = 0;
        foreach(var linePositions in linesCharactersPositions)
        {
            for (int i = 0; i < linePositions.Count; i++)
            {
                if (linePositions[i].Contains(e.Location))
                {
                        
                    label1.Text = "Index: " + (i+characterCount);
                }
            }
            characterCount += linePositions.Count;
        }
        
    }
