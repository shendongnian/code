    public void Reverse()
    {
        TimeSpan CurrentTime = (TimeSpan)storyboard.GetCurrentTime();
        TimeSpan sp = TimeSpan.FromSeconds(diffInSeconds);
        TimeSpan SubtractTime = sp.Subtract(CurrentTime);
        storyboard.Seek(SubtractTime, TimeSeekOrigin.Duration);
    }
