    private void SetBackgrounds(LevelObject levelObject)
    {
        if (levelObject.BackgroundResource != null)
        {
            gameAreaCanvas.SetBackgroundResource(levelObject.BackgroundResource);
        }
    }
---
    levelDisplay.Text = levelObject.Text;
    timer = new Timer();
    timer.Interval = levelObject.TimeInterval;
    timer.Enabled = true;
    timer.Elapsed += levelObject.ElapsedInterval;
    timer.Start();
