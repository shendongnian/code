    private void AttachAnimation(Slider slider)
    {
        var track = (Track)slider.Template.FindName("PART_Track", slider);
        var thumb = (Thumb)slider.Template.FindName("Thumb", slider);
        var shadow = (ContentControl)slider.Template.FindName("ThumbShadow", slider);
        var selection = (RepeatButton)slider.Template.FindName("PART_SelectionRange", slider);
        var border = (Border)slider.Template.FindName("Border", slider);
        var center = shadow.Width / 2;
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
            if (selection.ActualWidth + center > track.ActualWidth)
                correction = track.ActualWidth - center; // prevent going outside of bounds.
            var ratio = correction/track.ActualWidth;
            if (animation.To == ratio)
                return; // to prevent animation freeze when there is no need for animation change.
            animation.To = ratio;
            storyboard.Stop(border);
            storyboard.Begin(border, true);
        };
        
        slider.ValueChanged += async (o, args) =>
        {
            if(thumb.IsDragging) return; // drag delta will handle animation.
            await Task.Delay(10); // wait for value changes
            beginAnimation();
        };
        thumb.DragStarted += (o, args) => beginAnimation();
        thumb.DragDelta += (o, args) => beginAnimation();
        thumb.DragCompleted += async (o, args) =>
        {
            if (args.Canceled) await Task.Delay(10); // wait for value changes
            beginAnimation();
        };
        // at startup initialize values.
        var init = selection.ActualWidth;
        if (selection.ActualWidth + center > track.ActualWidth) init -= center;
        border.Tag = init / track.ActualWidth;
        storyboard.Begin(); // this will warm up animation to be ready for first time.
    }
