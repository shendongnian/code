    using (DrawingContext dc = _dv.RenderOpen())
    {
        GuidelineSet guidelineSet = new GuidelineSet();
        guidelineSet.GuidelinesX.Add(0.5);
        guidelineSet.GuidelinesY.Add(0.5);
        dc.PushGuidelineSet(guidelineSet);
    
        // Draw grid
    }
