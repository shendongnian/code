    Storyboard storyBoard = new Storyboard();
    int gridRowLimit = 5; // here you can set how many rows your grid has
    
    Int32AnimationUsingKeyFrames intKeyFrame = new Int32AnimationUsingKeyFrames();
    intKeyFrame.Duration = new TimeSpan(0, 0, 0, 0, gridRowLimit * 500);
    
    for (int i = 1; i < gridRowLimit; i++)
    {
        intKeyFrame.KeyFrames.Add(new DiscreteInt32KeyFrame(i));
    }
    
    Storyboard.SetTargetProperty(intKeyFrame, new PropertyPath("(Grid.Row)"));
    Storyboard.SetTarget(intKeyFrame, yourControl);
    
    storyBoard.Children.Add(intKeyFrame);
    storyBoard.Begin();
