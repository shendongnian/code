    /// <summary>
    /// Add fixed page to current fixed document
    /// </summary>
    /// <param name="card"></param>
    /// <param name="flags"></param>
    public void AddFixedPage(FixedPage card, ElementFlags flags)
    {
        card.Measure(_infiniteSize);
        if (CurX > _fixedDocument.DocumentPaginator.PageSize.Width - MarginX)
        {
            CurY += card.DesiredSize.Height + MarginY;
            CurX = MarginX;
        }
        double extraCheck = 0;
        if ((flags & ElementFlags.BottomCheck2) == ElementFlags.BottomCheck2)
            extraCheck = card.DesiredSize.Height;
        if (CurY > _fixedDocument.DocumentPaginator.PageSize.Height - MarginY - extraCheck)
            StartPage();
                    
    
        _curCanvas.Children.Add(card);
        card.SetValue(Canvas.LeftProperty, CurX);
        card.SetValue(Canvas.TopProperty, CurY);
    
    
        CurX += card.DesiredSize.Width + MarginX; //Added margin x for proper display             
    
        if (((flags & ElementFlags.NewLine) == ElementFlags.NewLine)  || CurX + card.DesiredSize.Width > _fixedDocument.DocumentPaginator.PageSize.Width) 
        {
            CurX = MarginX;
            CurY += card.DesiredSize.Height + MarginY;
        }
    }
