        // Create the storyboard that will be played
        var storyboard = new Storyboard();
        // Create the animation objects for each row change and add them to the storyboard
        var currentBeginTime = TimeSpan.Zero;
        for (var i = 0; i < number; i++)
        {
            var animation = new Int32Animation();
            // Set all the properties that you set on your animation objects before, and additionally use BeginTime
            animation.BeginTime = currentBeginTime;
            storyboard.Children.Add(animation);
            // Update the currentBeginTime to achieve the staggering effect
            currentBeginTime += TimeSpan.FromMilliseconds(50);
        }
        // Finally, start the Storyboard to run all animations
        storyboard.Begin();
        
    }
