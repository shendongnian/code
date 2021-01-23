    if (int.Parse(size) > 5 && int.Parse(size) < 15)
    {
        Rect1.Height = Rect1.ActualHeight - 10;
        Rect1.Width = Rect1.ActualWidth - 5;
    }
    else if(some other condition)
    {
        ...
    }
    else if(some other condition again)
    {
        ...
    }
    else
    {
        //if no other conditions are satisfied, this gets executed.
        //it's like the default case in a switch statement
    }
