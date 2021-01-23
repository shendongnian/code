    List<List<RectangleF>> linesCharactersPositions = new List<List<RectangleF>>();
    private void Form3_Paint(object sender, PaintEventArgs e)
    {
        linesCharactersPositions = new List<List<RectangleF>>();
        string[] lines = new string[] { "12345678  0234567890123456789012asdjkhfkjasdhfklhasdlkfjhlasdkjhfasdlfhlasdc",
                                            "vm,xv,cxznvrtrutyquiortorutoqwruyoiurweyoquitiqwrtiqwetryqweiufhsduafh" };
        Font f = new Font("Arial", 18);
        int lineY = 10;
        foreach (string line in lines)
        {
            DrawLongStringWithCharacterBounds(e.Graphics, line, new Font("Arial", 18), new PointF(10, lineY));
            linesCharactersPositions.Add(MeasureCharacters(e.Graphics, f,lineY, line));
            lineY += 20;
        }
            
    }
    
