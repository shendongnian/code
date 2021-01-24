    public void DrawText(FormattedText formattedText, Point point)
    {
        context.SaveState();
        context.ScaleCTM(1, -1); 
        context.SetFillColor(formattedText.Brush.Color.ToiOS());
   
        var sizeOfText = formattedText.DesiredSize;
        var ctFont = new CTFont(formattedText.FontName, formattedText.FontSize);
        var attributedString = new NSAttributedString(formattedText.Text,
            new CTStringAttributes
            {
                ForegroundColor = formattedText.Brush.Color.ToiOS(),
                Font = ctFont
            });
        context.TextPosition = new CGPoint(point.X, -(point.Y + sizeOfText.Height - ctFont.DescentMetric));
        using (var textLine = new CTLine(attributedString))
        {               
            textLine.Draw(context);
        }
        
        context.RestoreState();
    }
