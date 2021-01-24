    if (e.DeltaManipulation.Rotation < 0)
    {
        Debug.WriteLine("counterclockwise");
    }
    else if (e.DeltaManipulation.Rotation > 0)
    {
        Debug.WriteLine("clockwise");
    }
