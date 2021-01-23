    var track = (Track)PlaybackSlider.Template.FindName("PART_Track", PlaybackSlider);
    var thumb = (Thumb)PlaybackSlider.Template.FindName("Thumb", PlaybackSlider);
    var shadow = (ContentControl)PlaybackSlider.Template.FindName("ThumbShadow", PlaybackSlider);
    var selection = (RepeatButton)PlaybackSlider.Template.FindName("PART_SelectionRange", PlaybackSlider);
    var border = (Border)PlaybackSlider.Template.FindName("Border", PlaybackSlider);
    var center = shadow.Width/2;
    DoubleAnimation animation = new DoubleAnimation
    {
        DecelerationRatio = 1,
        Duration = TimeSpan.FromMilliseconds(200)
    };
    Storyboard storyboard = new Storyboard
    {
        Children = new TimelineCollection { animation }
    };
    Storyboard.SetTarget(animation, border);
    Storyboard.SetTargetProperty(animation, new PropertyPath("Tag"));
    Action beginAnimation = () =>
    {
        var correction = selection.ActualWidth;
        if (selection.ActualWidth + center > track.ActualWidth) correction -= center;
        var ratio = correction/track.ActualWidth;
        animation.To = ratio;
        storyboard.Begin();
    };
    
    PlaybackSlider.ValueChanged += (o, args) => beginAnimation();
    thumb.DragStarted += (o, args) => beginAnimation();
    thumb.DragDelta += (o, args) => beginAnimation();
    thumb.DragCompleted += (o, args) => beginAnimation();
